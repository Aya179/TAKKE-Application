using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Takke.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Text;
namespace Takke.Controllers
{
    public class MobileClientController : Controller
    {

        TakkeContext context;
        private IConfiguration _config;

        public MobileClientController(TakkeContext context, IConfiguration configuration) {
            this.context = context;
            _config = configuration;

        }

       

        

        [HttpGet("gettoken")]
        private Object GetToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddDays(1300),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
       

        [AllowAnonymous]
        [HttpPost]
        public IActionResult addNewClient(string ClientMobile)
        {
            Client client = new Client();
            client.RegisterationDate = DateTime.Now;
            client.ClientMobile = ClientMobile;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddDays(1300),
              signingCredentials: creds);

            client.Token = new JwtSecurityTokenHandler().WriteToken(token);
            ActivationCode code = new ActivationCode();
            client.ClientName = "new ";
            client.ClientBirthday = DateTime.Now;
           
            client.ClientGender = false;
           
            client.IsActive = false;
            client.IsDeleted = false;
            client.Notes = "new registeration";
            client.ClientNumber = "1123";
            client = context.Clients.Add(client).Entity;
            context.SaveChanges();
            code.Code = generatCode();
            code.CreatingDate = DateTime.Now;
            return Ok(new { client = client });
            //client.ActivationCodes
        }

        [HttpPost]
        public async Task<IActionResult> updateClient(int clientid,string clientName, string clientemail,bool gender,
            string birthdate) {
            try
            {
                Client client =await context.Clients.FindAsync(clientid);
                System.Console.WriteLine(client.ClientId);
                client.ClientGender = gender;
                client.ClientBirthday = DateTime.Parse(birthdate);
                client.Email = clientemail;
                client.IsActive = true;
                client.Notes = "Is updated at " + DateTime.Now.ToShortDateString();
                context.Clients.Update(client);
                await context.SaveChangesAsync();
                return Ok(new { client = client });
            }catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                    return Ok(new { client = "hello" }); }
        }

        [AllowAnonymous]
        [HttpGet]
        public  IActionResult getAllClients() {
            Client[] clients=null;
            try
            {
                clients =  context.Clients.ToArray();

                return Ok(new { clients = clients });
            }
            catch (Exception ex){
                System.Console.WriteLine(ex.Message);
                return Ok(new { clients = "hello" });
            }
             
           

        }



        public string generatCode()
        {
            Random random = new Random();
            int i = random.Next(100000, 999999);
            return i.ToString();

        }


        [HttpPost]
        public IActionResult sendRequest(int clientid,int driverId, int typeId,string sourcelocation,
            string sourcedetails,string destinationdetails,string  destinationlocation)
        { 
            Order order = new Order();
            order.ClientId = clientid;
            order.DriverId = driverId;
            order.OrderDate = DateTime.Now;
            order.Cost = 0;
            order.Orderstarttime = DateTime.Now;
            order.ApproximateCost = 0;
            order.Paid = 100;
            order.OrderType = typeId;
            order.SourceLocation = sourcelocation;
            order.SourceDetails = sourcedetails;
            order.DestenationDetails = destinationdetails;
            order.DestenationLocation = destinationlocation;
            order.Clientarrivingtime = DateTime.Now;
            order.Clientarrivingtime = DateTime.Now;
            order.Driverarrivingtime = DateTime.Now;
            order.Estimatedarrivingtime = DateTime.Now;

            order.Status = "0";
            context.Orders.Add(order);
            context.SaveChanges();
            order.Client = null;
            order.Driver = null;
            order.OrderTypeNavigation = null;
            return Ok(new { order = order });
        }

        [HttpGet]
        public IActionResult getFinishOrders(int clientId)
        {
            Order[] orders = context.Orders.Where(m => m.ClientId == clientId && m.Status == "3").ToArray();
            for(int i = 0; i < orders.Length; i++)
            {
                orders[i].OrderTypeNavigation = null;
                orders[i].Driver = null;
                orders[i].Client = null;
            }
            return Ok(new { orders = orders });
        }

        [HttpGet]
        public IActionResult getAllOrders(int clientId)
        {
            Order[] orders = context.Orders.Where(m => m.ClientId == clientId ).ToArray();
            for (int i = 0; i < orders.Length; i++)
            {
                orders[i].OrderTypeNavigation = null;
                orders[i].Driver = null;
                orders[i].Client = null;
            }
            return Ok(new { orders = orders });
        }


        [HttpGet]
        public IActionResult getAllCars()
        {
            Car[] cars = context.Cars.ToArray();
            return Ok(new { cars = cars });
        }

        [HttpGet]
        public IActionResult getPayemtns(int clientid)
        {
            ClientPayment[] payment = context.ClientPayments.Where(m => m.ClientId == clientid).ToArray();
            for(int i = 0; i < payment.Length; i++)
            {
                payment[i].Client = null;
                
            }
            return Ok(new { payemnts = payment });
        }

        [HttpGet]
        public IActionResult getAllDrivers()
        {
            Driver[] drivers = context.Drivers.ToArray();
            for(int i = 0; i < drivers.Length; i++)
            {
                Car[] cars = context.Cars.Where(m => m.DriverId == drivers[i].DriverId).ToArray();
                for(int j = 0; j < cars.Length; j++)
                {
                    cars[j].Driver = null;                    
                }
                drivers[i].Cars = cars;
                drivers[i].DriverPayments = null;
                drivers[i].DriverSalaries = null;
                drivers[i].Orders = null;
                
            }
            return Ok(new { drivers = drivers });
        }


        [HttpGet]
        public double getDriverRating(int driverid)
        {
            return 3;
        }
    }
}
