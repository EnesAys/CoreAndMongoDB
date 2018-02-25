using CoreAndMongoDB.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreAndMongoDB.UI.Controllers
{
    public class ContactsController : Controller
    {
        #region List
        public IActionResult Index()
        {
            IEnumerable<Contact> contactList;
            try
            {

                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("contact").Result;
                contactList = response.Content.ReadAsAsync<IEnumerable<Contact>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return View(contactList);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("contact", contact).Result;
            if (response.Content.ReadAsAsync<bool>().Result)
            {
                TempData["SuccessMessage"] = "Saved Succesfully";
            }
            else
                TempData["SuccessMessage"] = "Fail";
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        public IActionResult Edit(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("ID Alınamadı");
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("contact/" + id).Result;

            return View(response.Content.ReadAsAsync<Contact>().Result);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("contact/" + contact.ID, contact).Result;
            if (response.Content.ReadAsAsync<bool>().Result)
            {
                TempData["SuccessMessage"] = "Updated Succesfully";
            }
            else
                TempData["SuccessMessage"] = "Fail";
            return RedirectToAction("Index");
        }
        #endregion

        //#region Delete
        //public IActionResult Delete(string id) {
        //    HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("contact/" + id).Result;
        //    if (response.Content.ReadAsAsync<bool>().Result)
        //    {
        //        TempData["SuccessMessage"] = "Deleted Succesfully";
        //    }
        //    else
        //        TempData["SuccessMessage"] = "Fail";
        //    return RedirectToAction("Index");
        //}

        //#endregion
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("ID Alınamadı");
            }

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("contact/" + id).Result;

            return View(response.Content.ReadAsAsync<Contact>().Result);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("contact/" + id).Result;
                if (response.Content.ReadAsAsync<bool>().Result)
                {
                    TempData["SuccessMessage"] = "Deleted Succesfully";
                }
                else
                    TempData["SuccessMessage"] = "Fail";

            }
            catch (Exception ex)
            {

                TempData["SuccessMessage"] = "Fail";
            }
            return RedirectToAction("Index");
        }

    }
}
