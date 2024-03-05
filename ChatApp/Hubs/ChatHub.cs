using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs;

public sealed class ChatHub : Hub
{
	public async Task JoinRoom(string roomName, string userName)
	{
		await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
		await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{userName} has joined the room");
	}

	public async Task SendMessage(string roomName, string userName, string message)
	{
		await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{userName}: {message}");
	}
}