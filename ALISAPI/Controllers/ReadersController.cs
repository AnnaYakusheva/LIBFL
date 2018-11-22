﻿using ALISAPI.ALISErrors;
using ALISReaderRemote;
using DataProviderAPI.ValueObjects;
using LibflClassLibrary.ALISAPI.RequestObjects.Readers;
using LibflClassLibrary.ALISAPI.ResponseObjects;
using LibflClassLibrary.ALISAPI.ResponseObjects.Readers;
using LibflClassLibrary.Readers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace ALISAPI.Controllers
{
    public class ReadersController : ApiController
    {

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "Reader1", "Reader1444" };
        //}

        // GET api/Readers/5
        /// <summary>
        /// Получает читателя по номеру читательского билета
        /// </summary>
        /// <param name="id">Номер читательского билета</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Readers/{id}")]
        [ResponseType(typeof(ReaderInfo))]
        public HttpResponseMessage Get(int id)
        {
            ReaderInfo reader;
            try
            {
                reader = ReaderInfo.GetReader(id);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError("R004", Request, HttpStatusCode.NotFound);
            }
            return ALISResponseFactory.CreateResponse(reader, Request);
        }

        /// <summary>
        /// Получает читателя по Email
        /// </summary>
        /// <param name="email">Email читателя</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Readers/ByEmail/{email}")]
        [ResponseType(typeof(ReaderInfo))]
        public HttpResponseMessage Get(string email)
        {
            ReaderInfo reader;
            try
            {
                reader = ReaderInfo.GetReader(email);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError("R004", Request, HttpStatusCode.NotFound);
            }
            return ALISResponseFactory.CreateResponse(reader, Request);
        }


        /// <summary>
        /// Получить читателя по oauth-токену
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Readers/GetByOauthToken")]
        [ResponseType(typeof(ReaderInfo))]
        public HttpResponseMessage GetByOauthToken()
        {
            string JSONRequest = Request.Content.ReadAsStringAsync().Result;
            AccessToken request;
            try
            {
                request = JsonConvert.DeserializeObject<AccessToken>(JSONRequest, ALISSettings.ALISDateFormatJSONSettings);
            }
            catch
            {
                return ALISErrorFactory.CreateError("G001", Request, HttpStatusCode.BadRequest);
            }

            ReaderInfo reader;
            try
            {
                reader = ReaderInfo.GetReaderByOAuthToken(request);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError(ex.Message, Request, HttpStatusCode.InternalServerError);
            }

            return ALISResponseFactory.CreateResponse(reader, Request);
        }

        /// <summary>
        /// Изменить пароль читателя по номеру читателя и дате его рождения
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Readers/ChangePasswordLocalReader")]
        [ResponseType(typeof(ReaderInfo))]
        //[RequestType(typeof(ChangePassword))]
        public HttpResponseMessage ChangePasswordLocalReader()
        {
            
            string JSONRequest = Request.Content.ReadAsStringAsync().Result;
            ChangePasswordLocalReader request;
            try
            {
                request = JsonConvert.DeserializeObject<ChangePasswordLocalReader>(JSONRequest, ALISSettings.ALISDateFormatJSONSettings);
            }
            catch
            {
                return ALISErrorFactory.CreateError("G001", Request, HttpStatusCode.BadRequest);
            }

            ReaderInfo reader;
            try
            {
                reader = ReaderInfo.GetReader(request.NumberReader);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError("R004", Request, HttpStatusCode.NotFound);
            }
            try
            {
                reader.ChangePasswordLocalReader(request);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError(ex.Message, Request, HttpStatusCode.InternalServerError);
            }

            return ALISResponseFactory.CreateResponse(Request);
        }


        /// <summary>
        /// Авторизовать пользователя. Если авторизация успешна, то вернуть полный профиль. В качестве логина может быть использован как номер читателя, так и Email. 
        /// </summary>
        /// <param name="Login">Логин. Может быть номером читательского билета либо Email</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Readers/Authorize")]
        [ResponseType(typeof(ReaderInfo))]
        public HttpResponseMessage Authorize()
        {
            string JSONRequest = Request.Content.ReadAsStringAsync().Result;
            AuthorizeInfo request;
            try
            {
                request = JsonConvert.DeserializeObject<AuthorizeInfo>(JSONRequest, ALISSettings.ALISDateFormatJSONSettings);
            }
            catch
            {
                return ALISErrorFactory.CreateError("G001", Request, HttpStatusCode.BadRequest);
            }
            ReaderInfo reader;

            try
            {
                reader = ReaderInfo.Authorize(request);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError("R001", Request, HttpStatusCode.NotFound);
            }
            return ALISResponseFactory.CreateResponse(reader, Request);
        }



        /// <summary>
        /// Получить тип логина для заданного логина. 
        /// </summary>
        /// <param name="Login">Логин. Может быть номером читательского билета либо Email</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Readers/GetLoginType/{login}")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage GetLoginType(string Login)
        {
            string result = ReaderInfo.GetLoginType(Login);
            if (result.ToLower() == "notdefined")
            {
                return ALISErrors.ALISErrorFactory.CreateError("R003", Request, HttpStatusCode.NotFound);
            }
            LoginType type = new LoginType();
            type.LoginTypeValue = result;
            return ALISResponseFactory.CreateResponse(type, Request);
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                              Registration
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        string RegisterConnectionString = "Data Source=80.250.173.142;Initial Catalog=Readers;Persist Security Info=True;User ID=demo;Password=demo;Connect Timeout=1200";
        /// <summary>
        /// Пререгистрация удалённого читателя. Создаёт временную запись удалённого пользователя, которую нужно подтвердить. 
        /// Высылается письмо на указанный ящик со ссылкой для подтверждения регистрации.
        /// Ссылка действительна 24 часа, после чего регистрацию нужно проходить заново.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Readers/PreRegisterRemoteReader")]
        [ResponseType(typeof(ReaderInfo))]
        public HttpResponseMessage PreRegisterRemoteReader()
        {
            ALISReaderRemote.ReaderRemote re = new ALISReaderRemote.ReaderRemote(RegisterConnectionString);
            string JSONRequest = Request.Content.ReadAsStringAsync().Result;
            PreRegisterRemoteReader request;
            try
            {
                request = JsonConvert.DeserializeObject<PreRegisterRemoteReader>(JSONRequest, ALISSettings.ALISDateFormatJSONSettings);
            }
            catch
            {
                return ALISErrorFactory.CreateError("G001", Request, HttpStatusCode.BadRequest);
            }

            try
            {
                re.RegSendEmailAndSaveTemp(request.FamilyName,request.Name, request.FatherName, request.BirthDate, request.Email, request.CountryId, request.MobilePhone, request.Password);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError(ex.Message, Request, HttpStatusCode.InternalServerError);
            }
            return ALISResponseFactory.CreateResponse(Request);
        }

        /// <summary>
        /// Подверждение регистрации. Метод должен вызываться, когда читатель нажимает на ссылку, полученную на email указанный в пререгистрации.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Readers/ConfirmRegistrationRemoteReader")]
        [ResponseType(typeof(ReaderInfo))]
        public HttpResponseMessage ConfirmRegistrationRemoteReader()
        {
            ReaderRemote re = new ALISReaderRemote.ReaderRemote(RegisterConnectionString);
            string JSONRequest = Request.Content.ReadAsStringAsync().Result;
            ConfirmRegistrationRemoteReader request;
            
            try
            {
                request = JsonConvert.DeserializeObject<ConfirmRegistrationRemoteReader>(JSONRequest, ALISSettings.ALISDateFormatJSONSettings);
            }
            catch
            {
                return ALISErrorFactory.CreateError("G001", Request, HttpStatusCode.BadRequest);
            }

            try
            {
                re.RegSaveBaseAndDelTemp(request.Url);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError(ex.Message, Request, HttpStatusCode.InternalServerError);
            }
            return ALISResponseFactory.CreateResponse(Request);
        }

        /// <summary>
        /// Изменить пароль читателя с помощью Email. Отправляет письмо на указанный адрес, в котором содержится ссылка для восстановления пароля.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Readers/ChangePasswordByEmail")]
        [ResponseType(typeof(ReaderInfo))]
        public HttpResponseMessage ChangePasswordByEmail()
        {

            string JSONRequest = Request.Content.ReadAsStringAsync().Result;
            ChangePasswordByEmail request;
            try
            {
                request = JsonConvert.DeserializeObject<ChangePasswordByEmail>(JSONRequest, ALISSettings.ALISDateFormatJSONSettings);
            }
            catch
            {
                return ALISErrorFactory.CreateError("G001", Request, HttpStatusCode.BadRequest);
            }

            ReaderRemote re = new ReaderRemote(RegisterConnectionString);

            try
            {
                re.PasSendEmailAndSaveTemp(request.Email);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError(ex.Message, Request, HttpStatusCode.InternalServerError);
            }
            return ALISResponseFactory.CreateResponse(Request);
        }

        /// <summary>
        /// Записывает пароль удалённого читателя в базу. 
        /// Необходимо указать ссылку по которой читатель пришёл для восстановления пароля и пароль.
        /// Метод относится к сценарию восстановления пароля по email. Это последний метод сценария. После того, как ссылки проверились на существование.
        /// Нельзя путать этот метод с методом для восстановления пароля по дате рождения!!! 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Readers/SetPasswordRemoteReader")]
        [ResponseType(typeof(ReaderInfo))]
        public HttpResponseMessage SetPasswordRemoteReader()
        {

            string JSONRequest = Request.Content.ReadAsStringAsync().Result;
            SetPasswordRemoteReader request;
            try
            {
                request = JsonConvert.DeserializeObject<SetPasswordRemoteReader>(JSONRequest, ALISSettings.ALISDateFormatJSONSettings);
            }
            catch
            {
                return ALISErrorFactory.CreateError("G001", Request, HttpStatusCode.BadRequest);
            }

            ReaderRemote re = new ReaderRemote(RegisterConnectionString);

            try
            {
                re.PasSaveBaseAndDelTemp(request.Url,request.Password);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError(ex.Message, Request, HttpStatusCode.InternalServerError);
            }
            return ALISResponseFactory.CreateResponse(Request);
        }

        /// <summary>
        /// Проверить ссылку для восстановления пароля на действительность.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Readers/CheckPasswordUrl")]
        [ResponseType(typeof(ReaderInfo))]
        public HttpResponseMessage CheckPasswordUrl()
        {
            string JSONRequest = Request.Content.ReadAsStringAsync().Result;
            CheckPasswordUrl request;
            try
            {
                request = JsonConvert.DeserializeObject<CheckPasswordUrl>(JSONRequest, ALISSettings.ALISDateFormatJSONSettings);
            }
            catch
            {
                return ALISErrorFactory.CreateError("G001", Request, HttpStatusCode.BadRequest);
            }

            ReaderRemote re = new ReaderRemote(RegisterConnectionString);

            try
            {
                re.PasGetURL(request.Url);
            }
            catch (Exception ex)
            {
                return ALISErrorFactory.CreateError(ex.Message, Request, HttpStatusCode.InternalServerError);
            }
            return ALISResponseFactory.CreateResponse(Request);
        }



    }
}
