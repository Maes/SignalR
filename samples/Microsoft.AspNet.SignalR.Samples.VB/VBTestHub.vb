' SignalR
Imports Microsoft.AspNet.SignalR
Imports Microsoft.AspNet.SignalR.Hubs

<HubName("VBDemo")>
Public Class VbDemoHub
    Inherits Hub

    Public Overrides Function OnConnected() As Task
        Clients.CallerState.message = "Why?"

        ' Invoke a method on the client so the updated state is also sent
        Clients.Caller.anyMethodNameWillDo()

        Return MyBase.OnConnected()
    End Function

    Public Function ReadStateValue()
        Dim z As String = Clients.CallerState.message
        Return z
    End Function
End Class
