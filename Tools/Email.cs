using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Linq;


namespace ExameApi.Tools
{
    public class EMail
    {
        #region Propriedades

        private System.Net.Mail.MailMessage _message;
        public System.Net.Mail.MailMessage Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private System.Net.Mail.SmtpClient _smtp;
        public System.Net.Mail.SmtpClient Smtp
        {
            get { return _smtp; }
            set { _smtp = value; }
        }

        public int Port
        {
            get { return Smtp.Port; }
            set { Smtp.Port = value; }
        }

        public bool EnableSsl
        {
            get { return Smtp.EnableSsl; }
            set { Smtp.EnableSsl = value; }
        }

        public string Acount { get; set; }
        public string PassWord { get; set; }
        public IList<string> ToAddress { get; set; }
        public IList<string> ToAddressCopy { get; set; }
        public IList<string> FileAttached { get; set; }
        public string FromAddress { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

        #endregion Propriedades

        #region Construtor

        public EMail()
        {
            Message = new System.Net.Mail.MailMessage();
            if (ToAddress == null)
            {
                ToAddress = new List<string>();
            }
            if (ToAddressCopy == null)
            {
                ToAddressCopy = new List<string>();
            }
            if (FileAttached == null)
            {
                FileAttached = new List<string>();
            }
        }

        #endregion Construtor

        #region Metodos

        public void AddTo(string pToAddress)
        {
            ToAddress.Add(pToAddress);
        }

        public void AddCopy(string pToAddress)
        {
            ToAddressCopy.Add(pToAddress);
        }

        public void ClearTo()
        {
            ToAddress.Clear();
        }

        public void AddAttachment(string pFileAttached)
        {
            FileAttached.Add(pFileAttached);
        }

        public void ClearAttachment()
        {
            FileAttached.Clear();
        }

        public void Client(string ds_smtp_host)
        {
            Smtp = new System.Net.Mail.SmtpClient(ds_smtp_host);
        }

        public string Send()
        {
            string retorno = string.Empty;

            Message.BodyEncoding = UTF8Encoding.UTF8;
            Message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            Message.From = new System.Net.Mail.MailAddress(FromAddress);

            FileAttached.ToList().ForEach(x => Message.Attachments.Add(new System.Net.Mail.Attachment(x)));

            ToAddress.ToList().ForEach(x => Message.To.Add(new System.Net.Mail.MailAddress(x)));

            ToAddressCopy.ToList().ForEach(x => Message.CC.Add(new System.Net.Mail.MailAddress(x)));

            Message.Subject = Subject;
            Message.Body = Body;
            Smtp.UseDefaultCredentials = false;
            Smtp.Timeout = 180000;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            Smtp.Credentials = new System.Net.NetworkCredential(Acount, PassWord);

            try
            {
                Smtp.Send(Message);
                retorno = "";
            }
            catch (Exception ex_)
            {
                retorno = ex_.InnerException != null ? (ex_.InnerException).Message : ex_.Message;
            }

            return retorno;
        }

        #endregion Metodos
    }

    public class SmtpParameter{
        public string ds_email_adress { get; set; }

        public string ds_smtp_password { get; set; }

        public string ds_smtp_host { get; set; }

        public int nr_smtp_port { get; set; }

        public string ds_pop3_host { get; set; }

        public int nr_pop3_port { get; set; }

        public string fl_servidor_requer_SSl { get; set; }
        public string SituacaoSSl { get { return fl_servidor_requer_SSl == "S" ? "checked" : ""; } }

    }
}
