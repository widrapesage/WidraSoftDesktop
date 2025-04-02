using Tunnel.Communication.Clients;
using Tunnel.Communication.Data;
using Tunnel.Communication.Models;

namespace TunnelIntegration
{
    public static class TunnelCommunicationHelper
    {
        private static string _clientIdentifier = null!;
        private static string _clientType = null!;
        private static string _weightSenderType = null!;
        private static string _weightReceiverType = null!;
        private static string _hubUrl = null!;

        private static SystemEndpoint _sourceEndpoint = null!;
        private static TunnelCommunicationClient _tunnelClient = null!;

        public static event EventHandler<WeightData>? ReceivedWeightData;

        public static async Task InitialiseAsync(TunnelIntegrationSettings settings)
        {
            _clientIdentifier = settings.ClientIdentifier;
            _clientType = settings.ClientType;
            _weightSenderType = settings.WeightSenderType;
            _weightReceiverType = settings.WeightReceiverType;
            _hubUrl = settings.HubUrl;

            _sourceEndpoint = new SystemEndpoint
            {
                Identifier = _clientIdentifier,
                Type = DestinationType.SignalRClient
            };

            _tunnelClient = new TunnelCommunicationClient(_hubUrl, _sourceEndpoint);

            await _tunnelClient.ConnectAsync();
            await _tunnelClient.RegisterClientAsync(new ClientRegistrationRequest { Name = _clientIdentifier, Type = _clientType });

            if (_clientType == _weightReceiverType)
                _tunnelClient.ReceivedWeightData += TunnelClientReceivedWeightData;
        }

        public static async Task SendWeightMessageAsync(int weight, bool stable)
        {
            if (_clientType == _weightSenderType)
            {
                List<ClientInfo> clients = await _tunnelClient.DiscoverClientsAsync(new ClientRegistrationRequest { Type = _weightReceiverType });

                if (clients.Count > 0)
                {
                    foreach (ClientInfo clientInfo in clients)
                    {
                        await _tunnelClient.SendMessageAsync(new TunnelMessage(_sourceEndpoint,
                                                                              new SystemEndpoint
                                                                              {
                                                                                  Identifier = clientInfo.ClientId,
                                                                                  Type = DestinationType.SignalRClient
                                                                              },
                                                                              CommandType.SendWeight,
                                                                              new WeightData
                                                                              {
                                                                                  Weight = weight,
                                                                                  Stabilized = stable
                                                                              }));
                    }
                }
            }
        }

        public static bool IsWeightReceiver()
        {
            return _clientType == _weightReceiverType;
        }

        private static void TunnelClientReceivedWeightData(object? sender, WeightData e)
        {
            ReceivedWeightData?.Invoke(null, e);
        }
    }
}
