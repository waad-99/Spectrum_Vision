using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VirtualKeyboardManager : MonoBehaviour
{
    public GameObject virtualKeyboard;      // «·ﬂÌ»Ê—œ «·«› —«÷Ì
    public TMP_InputField nameInputField;   // Õﬁ· ≈œŒ«· «·«”„
    public TMP_InputField emailInputField;  // Õﬁ· ≈œŒ«· «·«Ì„Ì·
    public string attachmentPath;           // „”«— «·„—›ﬁ« 

    private RectTransform keyboardBackground;
    private bool isKeyboardVisible = false;

    void Awake()
    {
        // «· √ﬂœ „‰ √‰ «·ﬂÌ»Ê—œ „ÊÃÊœ ›Ì «·„‘Âœ
        if (virtualKeyboard == null)
        {
            Debug.LogError("Please assign the virtual keyboard GameObject in the inspector.");
            return;
        }

        // «· √ﬂœ „‰ √‰ «·ÕﬁÊ·  „ —»ÿÂ« »‘ﬂ· ’ÕÌÕ
        if (nameInputField == null || emailInputField == null)
        {
            Debug.LogError("Please assign the InputFields in the inspector.");
            return;
        }

        keyboardBackground = virtualKeyboard.transform.Find("Background").GetComponent<RectTransform>();
    }

    void Update()
    {
        // «· »œÌ· »Ì‰ «·„œŒ·«  ⁄‰œ «·÷€ÿ ⁄·Ï Tab
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

        // «· »œÌ· »Ì‰ «·„œŒ·«  »«” Œœ«„ “— Fire1
        if (Input.GetButtonDown("Fire1"))  // «” »œ· "Fire1" »“—  Õﬂ„ „⁄Ì‰
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

        // ≈—”«· «·»Ì«‰«  ⁄‰œ «·÷€ÿ ⁄·Ï Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SubmitData(); // ≈—”«· «·»Ì«‰« 
        }
    }

    // › Õ «·ﬂÌ»Ê—œ
    public void OpenKeyboard()
    {
        if (virtualKeyboard != null && !isKeyboardVisible)
        {
            virtualKeyboard.SetActive(true);
            isKeyboardVisible = true;
            SetupKeyboardSize();
        }
    }

    // €·ﬁ «·ﬂÌ»Ê—œ
    public void CloseKeyboard()
    {
        if (virtualKeyboard != null && isKeyboardVisible)
        {
            virtualKeyboard.SetActive(false);
            isKeyboardVisible = false;
        }
    }

    // ≈⁄œ«œ ÕÃ„ «·ﬂÌ»Ê—œ »‰«¡ ⁄·Ï «·‘«‘…
    private void SetupKeyboardSize()
    {
        float keyboardWidth = 485;  // ⁄—÷ «·ﬂÌ»Ê—œ
        float keyboardHeight = 485; // «— ›«⁄ «·ﬂÌ»Ê—œ

        if (keyboardBackground != null)
        {
            keyboardBackground.sizeDelta = new Vector2(keyboardWidth, keyboardHeight);
        }
    }

    // ⁄‰œ„« Ì „ «·÷€ÿ ⁄·Ï «”„ «·„œŒ·
    public void OnNameFieldSelected()
    {
        OpenKeyboard();
    }

    // ⁄‰œ„« Ì „ «·÷€ÿ ⁄·Ï «Ì„Ì· «·„œŒ·
    public void OnEmailFieldSelected()
    {
        OpenKeyboard();
    }

    // ⁄‰œ ﬂ «»… «·‰’ ›Ì «·ﬂÌ»Ê—œ
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

    // ⁄‰œ «·÷€ÿ ⁄·Ï “— «·„”Õ
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

    // ⁄‰œ «—”«· «·»Ì«‰«  ··≈Ì„Ì·
    public void SubmitData()
    {
        string name = nameInputField.text;
        string email = emailInputField.text;

        // ≈—”«· «·»—Ìœ «·≈·ﬂ —Ê‰Ì
        SendEmail(name, email);
    }

    // «·ﬂÊœ «·Œ«’ »≈—”«· «·»—Ìœ «·≈·ﬂ —Ê‰Ì
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
            // ≈÷«›… «·„—›ﬁ«  ≈–« ﬂ«‰ «·„”«— ’«·Õ«
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
