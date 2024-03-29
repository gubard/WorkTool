﻿namespace WorkTool.Core.Modules.SmsClub.Models;

public class SendSmsRequest
{
    [JsonPropertyName("phone")]
    public string[]? PhoneNumbers { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("src_addr")]
    public string? Recipient { get; set; }
}
