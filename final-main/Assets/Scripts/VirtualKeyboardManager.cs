using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VirtualKeyboardManager : MonoBehaviour
{
    public GameObject virtualKeyboard;      // �������� ���������
    public TMP_InputField nameInputField;   // ��� ����� �����
    public TMP_InputField emailInputField;  // ��� ����� �������
    public string attachmentPath;           // ���� ��������

    private RectTransform keyboardBackground;
    private bool isKeyboardVisible = false;

    void Awake()
    {
        // ������ �� �� �������� ����� �� ������
        if (virtualKeyboard == null)
        {
            Debug.LogError("Please assign the virtual keyboard GameObject in the inspector.");
            return;
        }

        // ������ �� �� ������ �� ����� ���� ����
        if (nameInputField == null || emailInputField == null)
        {
            Debug.LogError("Please assign the InputFields in the inspector.");
            return;
        }

        keyboardBackground = virtualKeyboard.transform.Find("Background").GetComponent<RectTransform>();
    }

    void Update()
    {
        // ������� ��� �������� ��� ����� ��� Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (nameInputField.isFocused)
            {
                emailInputField.Select();
            }
            else if (emailInputField.isFocused)
            {
                nameInputField.Select();
            }
        }

        // ������� ��� �������� �������� �� Fire1
        if (Input.GetButtonDown("Fire1"))  // ������ "Fire1" ��� ���� ����
        {
            if (nameInputField.isFocused)
            {
                emailInputField.Select();
            }
            else if (emailInputField.isFocused)
            {
                nameInputField.Select();
            }
        }

        // ����� �������� ��� ����� ��� Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SubmitData(); // ����� ��������
        }
    }

    // ��� ��������
    public void OpenKeyboard()
    {
        if (virtualKeyboard != null && !isKeyboardVisible)
        {
            virtualKeyboard.SetActive(true);
            isKeyboardVisible = true;
            SetupKeyboardSize();
        }
    }

    // ��� ��������
    public void CloseKeyboard()
    {
        if (virtualKeyboard != null && isKeyboardVisible)
        {
            virtualKeyboard.SetActive(false);
            isKeyboardVisible = false;
        }
    }

    // ����� ��� �������� ����� ��� ������
    private void SetupKeyboardSize()
    {
        float keyboardWidth = 485;  // ��� ��������
        float keyboardHeight = 485; // ������ ��������

        if (keyboardBackground != null)
        {
            keyboardBackground.sizeDelta = new Vector2(keyboardWidth, keyboardHeight);
        }
    }

    // ����� ��� ����� ��� ��� ������
    public void OnNameFieldSelected()
    {
        OpenKeyboard();
    }

    // ����� ��� ����� ��� ����� ������
    public void OnEmailFieldSelected()
    {
        OpenKeyboard();
    }

    // ��� ����� ���� �� ��������
    public void UpdateInputField(string inputText)
    {
        if (nameInputField.isFocused)
        {
            nameInputField.text = inputText;
        }
        else if (emailInputField.isFocused)
        {
            emailInputField.text = inputText;
        }
    }

    // ��� ����� ��� �� �����
    public void ClearInputField()
    {
        if (nameInputField.isFocused)
        {
            nameInputField.text = "";
        }
        else if (emailInputField.isFocused)
        {
            emailInputField.text = "";
        }
    }

    // ��� ����� �������� �������
    public void SubmitData()
    {
        string name = nameInputField.text;
        string email = emailInputField.text;

        // ����� ������ ����������
        SendEmail(name, email);
    }

    // ����� ����� ������ ������ ����������
    public void SendEmail(string name, string email)
    {
        string from = "waad.almaimoni1@gmail.com";
        string to = email;

        var mailConfig = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential("waad.almaimoni1@gmail.com", "iwgv yjkf dpzf tvnu"),
        };

        var messageConfig = new MailMessage(from, to)
        {
            Subject = "Your subject",
            Body = $"Dear {name},\nThis is a test email.",
        };

        try
        {
            // ����� �������� ��� ��� ������ ������
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
