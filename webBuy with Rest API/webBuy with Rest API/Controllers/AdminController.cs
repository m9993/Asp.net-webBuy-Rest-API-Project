using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webBuy_with_Rest_API.Attributes;
using webBuy_with_Rest_API.Models;
using webBuy_with_Rest_API.Repositories;
using webBuy_with_Rest_APIs.Models.ViewModel;

namespace webBuy_with_Rest_API.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        UserRepository userRepository = new UserRepository();
        OrderRepository orderRepository = new OrderRepository();
        ShopRepository shopRepository = new ShopRepository();
        ComissionRepository comissionRepository = new ComissionRepository();
        WithdrawRepository withdrawRepository = new WithdrawRepository();
        ReviewRepository reviewRepository = new ReviewRepository();
        ProductRepository productRepository = new ProductRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        PaymentRepository paymentRepository = new PaymentRepository();

        [Route("ChangePassword/{id}"), HttpPut, BasicAuthentication]
        public IHttpActionResult ChangePassword([FromBody] ChangePassword changePassword, [FromUri] int id)
        {
            if (changePassword.OldPassword == null || changePassword.NewPassword == null || changePassword.ConfirmNewPassword == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                User profile = userRepository.Get(id);
                if (profile.password != changePassword.OldPassword)
                {
                    return StatusCode(HttpStatusCode.Unauthorized);
                }
                else
                {
                    if (changePassword.NewPassword != changePassword.ConfirmNewPassword)
                    {
                        return StatusCode(HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        profile.password = changePassword.NewPassword;
                        userRepository.Update(profile);
                        return StatusCode(HttpStatusCode.OK);
                    }
                }
            }
        }

        [Route("AllEmails"),HttpGet]
        public IHttpActionResult AllEmails()
        {
            return Ok(userRepository.GetAll().Select(e => e.email));
            
        }
        
        [Route("UpdateUserProfile"), HttpPut, BasicAuthentication]
        public IHttpActionResult UpdateUserProfile([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Update(user);
                return StatusCode(HttpStatusCode.OK);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("GetTodaySells"), HttpGet]
        public IHttpActionResult GetTodaySells()
        {
            List<double> sumTotalInWeek = new List<double>();
            for (int i = 0; i < 7; i++)
            {
                var date = DateTime.Now.AddDays(-i).ToShortDateString();
                var listByDate = orderRepository.GetOrdersListByDate(date).ToList();
                double sumTotal = 0;
                foreach (var item in listByDate)
                {
                    sumTotal += (double)item.total;
                }
                sumTotalInWeek.Add(sumTotal);
            }

            return Ok(sumTotalInWeek);
        }

        [Route("AvailableBalanceInAllShops"), HttpGet]
        public IHttpActionResult AvailableBalanceInAllShops()
        {
            double balance = 0;
            var allShopDetails = shopRepository.GetAll().ToList();
            foreach (var item in allShopDetails)
            {
                balance += (double)item.balance;
            }
            //1.00
            var balanceInFraction = string.Format("{0:f2}", balance);
            return Ok(balanceInFraction);
        }

        [Route("GetTotalComission"), HttpGet]
        public IHttpActionResult GetTotalComission()
        {
            double balance = 0;
            var comissionDetails = comissionRepository.GetAll().ToList();
            foreach (var item in comissionDetails)
            {
                balance += (double)item.amount;
            }
            //1.00
            var balanceInFraction = string.Format("{0:f2}", balance);
            return Ok(balanceInFraction);
        }

        [Route("GetSellerWithdrawedMoney"), HttpGet]
        public IHttpActionResult GetSellerWithdrawedMoney()
        {
            double balance = 0;
            var sellerWithdrawDetails = withdrawRepository.SellerWithdraw().ToList();
            foreach (var item in sellerWithdrawDetails)
            {
                balance += (double)item.amount;
            }
            //1.00
            var balanceInFraction = string.Format("{0:f2}", balance);
            return Ok(balanceInFraction);
        }

        [Route("GetAdminWithdrawedMoney"), HttpGet]
        public IHttpActionResult GetAdminWithdrawedMoney()
        {
            double balance = 0;
            var adminWithdrawDetails = withdrawRepository.AdminWithdraw().ToList();
            foreach (var item in adminWithdrawDetails)
            {
                balance += (double)item.amount;
            }
            //1.00
            var balanceInFraction = string.Format("{0:f2}", balance);
            return Ok(balanceInFraction);
        }

        [Route("GetBannedUsersNotification"), HttpGet]
        public IHttpActionResult GetBannedUsersNotification()
        {
            var bannedUsers = userRepository.GetBannedUsers().ToList().Count();
            return Ok(bannedUsers);
        }

        [Route("GetBannedUsers"), HttpGet]
        public IHttpActionResult GetBannedUsers()
        {
            var bannedUsers = userRepository.GetBannedUsers().ToList();
            return Ok(bannedUsers);
        }

        [Route("GetAllUsers"), HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            var AllUsers = userRepository.GetAll().ToList();
            return Ok(AllUsers);
        }

        [Route("BanUser/{id}"), HttpPut]
        public IHttpActionResult BanUser(int id)
        {
            var user = userRepository.Get(id);
            user.userStatus = 0;
            userRepository.Update(user);
            return StatusCode(HttpStatusCode.OK);
        }

        [Route("UnbanUser/{id}"), HttpPut]
        public IHttpActionResult UnbanUser(int id)
        {
            var user = userRepository.Get(id);
            user.userStatus = 1;
            userRepository.Update(user);
            return StatusCode(HttpStatusCode.OK);
        }

        [Route("GetAllProductReviews"), HttpGet]
        public IHttpActionResult GetAllProductReviews()
        {
            List<ReviewProductShopView> listReviewProductShopView = new List<ReviewProductShopView>();

            var allReviews = reviewRepository.GetAll().ToList();
            foreach (var item in allReviews)
            {
                ReviewProductShopView reviewProductShopView = new ReviewProductShopView();
                reviewProductShopView.ProductId = item.productId;
                reviewProductShopView.UserId = item.userId;
                reviewProductShopView.Review = item.review;
                reviewProductShopView.Rating = (int)item.rating;

                var productDetails = productRepository.Get(item.productId);
                reviewProductShopView.ProductName = productDetails.name;

                var shopDetails = shopRepository.Get(productDetails.shopId);
                reviewProductShopView.ShopName = shopDetails.name;

                listReviewProductShopView.Add(reviewProductShopView);
            }

            return Ok(listReviewProductShopView);
        }

        [Route("GetAllProductReviewsOrderByDesc/{order}"), HttpGet]
        public IHttpActionResult GetAllProductReviewsOrderByDesc(string order)
        {
            List<ReviewProductShopView> listReviewProductShopView = new List<ReviewProductShopView>();

            var allReviews = reviewRepository.GetAll().ToList();
            if (order == "desc")
            {
                allReviews = reviewRepository.GetProductReviewsOrderByDesc().ToList();
            }
            foreach (var item in allReviews)
            {
                ReviewProductShopView reviewProductShopView = new ReviewProductShopView();
                reviewProductShopView.ProductId = item.productId;
                reviewProductShopView.UserId = item.userId;
                reviewProductShopView.Review = item.review;
                reviewProductShopView.Rating = (int)item.rating;

                var productDetails = productRepository.Get(item.productId);
                reviewProductShopView.ProductName = productDetails.name;

                var shopDetails = shopRepository.Get(productDetails.shopId);
                reviewProductShopView.ShopName = shopDetails.name;

                listReviewProductShopView.Add(reviewProductShopView);
            }
            return Ok(listReviewProductShopView);
        }

        [Route("GetProductDetailsWithCategoryShopName/{id}"), HttpGet]
        public IHttpActionResult GetProductDetailsWithCategoryShopName(int id)
        {
            var productDetails = productRepository.Get(id);
            ReviewProductShopView categoryProductShopView = new ReviewProductShopView();
            categoryProductShopView.ProductId = id;
            categoryProductShopView.ProductName = productDetails.name;
            categoryProductShopView.UnitPrice = (double)productDetails.unitPrice;
            categoryProductShopView.Quantity = (int)productDetails.quantity;
            categoryProductShopView.ProductStatus = (int)productDetails.productStatus;
            categoryProductShopView.ProductImage = productDetails.image;
            categoryProductShopView.ProductAddedDate = productDetails.date;

            var categoryDetails = categoryRepository.Get((int)productDetails.categoryId);
            categoryProductShopView.CategoryName = categoryDetails.name;

            var shopDetails = shopRepository.Get((int)productDetails.shopId);
            categoryProductShopView.ShopName = shopDetails.name;

            return Ok(categoryProductShopView);
        }

        [Route("GetProductRating/{productId}"), HttpGet]
        public IHttpActionResult GetProductRating(int productId)
        {
            int[] rating = { 0, 0, 0, 0, 0 };
            var reviewDetails = reviewRepository.GetProductReviews(productId).ToList();
            foreach (var item in reviewDetails)
            {
                if (item.rating == 1)
                {
                    rating[0]++;
                }
                if (item.rating == 2)
                {
                    rating[1]++;
                }
                if (item.rating == 3)
                {
                    rating[2]++;
                }
                if (item.rating == 4)
                {
                    rating[3]++;
                }
                if (item.rating == 5)
                {
                    rating[4]++;
                }
            }
            return Ok(rating);
        }

        [Route("PaymentMethodAdd"), HttpPost]
        public IHttpActionResult PaymentMethodAdd([FromBody]Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                paymentRepository.Insert(payment);
                return StatusCode(HttpStatusCode.OK);
            }
        }


        [Route("PaymentMethodEdit"), HttpPut]
        public IHttpActionResult PaymentMethodEdit(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                paymentRepository.Update(payment);
                return StatusCode(HttpStatusCode.OK);
            }
        }

        [Route("PaymentMethodDelete/{id}"), HttpDelete]
        public IHttpActionResult PaymentMethodDelete(int id)
        {
            paymentRepository.Delete(id);
            return StatusCode(HttpStatusCode.OK);
        }

        [Route("CategoryAdd"), HttpPost]
        public IHttpActionResult CategoryAdd(Category category)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                categoryRepository.Insert(category);
                return StatusCode(HttpStatusCode.OK);
            }
        }


        [Route("CategoryEdit"), HttpPut]
        public IHttpActionResult CategoryEdit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                categoryRepository.Update(category);
                return StatusCode(HttpStatusCode.OK);
            }
        }

        [Route("CategoryDelete/{id}"), HttpDelete]
        public IHttpActionResult CategoryDelete(int id)
        {
            categoryRepository.Delete(id);
            return StatusCode(HttpStatusCode.OK);

        }

        [Route("ShopUpdate"), HttpPut]
        public IHttpActionResult ShopUpdate(Shop shop)
        {
            if (ModelState.IsValid)
            {
                var getShop = shopRepository.Get(shop.shopId);
                getShop.setComission = shop.setComission;
                getShop.shopStatus = shop.shopStatus;
                shopRepository.Update(getShop);
                return StatusCode(HttpStatusCode.OK);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

        }
    
    
    }
}
