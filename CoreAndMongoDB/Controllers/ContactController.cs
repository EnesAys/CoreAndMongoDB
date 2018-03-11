using CoreAndMongoDB.IRepository;
using CoreAndMongoDB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoreAndMongoDB.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContactController:Controller
    {

        #region Ctor
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        #endregion


        #region GetAll
        /// <summary>
        /// Gets All Contacts Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /contact
        ///
        /// </remarks>
        /// <returns>Return Contact Items</returns>
        
        //[Authorize]
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            var contacts = await _contactRepository.GetAll();
            if (contacts == null)
            {
                throw new ArgumentException("Kayıt bulunamadı");
            }
            return contacts;
        }
        #endregion

        #region GetById
        /// <summary>
        /// Gets a spesific Contacts Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /contact/{id}
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Return spesific Contact Item</returns>


        [HttpGet("{id}")]
        public async Task<Contact> Get(string id)
        {
            var contact = await _contactRepository.Get(id) ?? throw new ArgumentException("ID alınamadı");
            return contact;
        }

        #endregion

        #region AddContact

        /// <summary>
        /// Creates a Contact Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /contact
        ///     {
        ///        "Name": "Enes",
        ///        "Surname":"Ays.",
        ///        "Adress":"BEŞİKTAŞ",
        ///        "Mail": "enes@enes.com",
        ///        "Phone": "05555555555"
        ///     }
        ///
        /// </remarks>
        /// <returns>Returns True or False. If response is true then request is 'Success' </returns>


        [HttpPost]
        public async Task<bool> Post([FromBody]Contact contact)
        {
            bool isSucced;
            try
            {
                if (await _contactRepository.Add(contact))
                {
                    isSucced = true;
                }
                else
                    isSucced = false;

            }
            catch (Exception)
            {
                isSucced = false;
            }

            return isSucced;
        }
        #endregion

        #region UpdateContact

        /// <summary>
        /// Update a Contact Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///   PUT/contact/{id}
        ///     {
        ///        "Name": "Enes",
        ///        "Surname":"Ays.",
        ///        "Adress":"BEŞİKTAŞ",
        ///        "Mail": "enes@enes.com",
        ///        "Phone": "05555555555"
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Returns True or False. If response is true then request is 'Success' </returns>

        [HttpPut("{id}")]
        public async Task<bool> Put(string id,[FromBody]Contact contact)
        {
            bool isSucceed;

            if (string.IsNullOrEmpty(id))
            {
                isSucceed = false;
                //throw new ArgumentException("Id Alınamadı");
                
            }
          
            try
            {
                if (await _contactRepository.Update(id,contact))
                {
                    isSucceed = true;
                }
                else
                    isSucceed = false;
            }
            catch (Exception)
            {
                isSucceed = false;
            }

            return isSucceed;
        }
        #endregion



        #region DeleteContact
        /// <summary>
        /// Delete a Contact Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///   DELETE/contact/{id}
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Returns True or False. If response is true then request is 'Success' </returns>

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id Alınamadı");
            }
            bool isSucceed;
            try
            {
                await _contactRepository.Remove(id);
                isSucceed = true;
            }
            catch (Exception)
            {
                isSucceed = false;
            }

            return isSucceed;
        }
        #endregion

    }
}
