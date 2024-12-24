using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;
using TMPro;

public class SendEmail : MonoBehaviour
{
    public TMP_InputField Name;
    public TMP_InputField Email;
    public string attachmentPath; // Path to the file to attach (can be set in Unity Inspector)

    public void Send()
    {
        string from = "waad.almaimoni1@gmail.com";
        string to = Email.text;

        var mailConfig = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential("waad.almaimoni1@gmail.com", "iwgv yjkf dpzf tvnu"),
        };

        var messageConfig = new MailMessage(from, to)
        {
            Subject = "your subject ",
            Body = $"Dear {Name.text}",
        };

        try
        {
            // Add attachment if the path is valid
            if (!string.IsNullOrEmpty(attachmentPath) && System.IO.File.Exists(attachmentPath))
            {
                Attachment attachment = new Attachment(attachmentPath);
                messageConfig.Attachments.Add(attachment);
            }
            else
            {
                Debug.LogWarning("Attachment path is invalid or file does not exist.");
            }

            mailConfig.Send(messageConfig);
            Debug.Log("Message Sent");
        }
        catch (Exception ex)
        {
            Debug.Log($"Error With: {ex.Message}");
        }
    }
}