using System.Collections.Generic;
using Angular2MultiSPA.Models;
using Angular2MultiSPA.ViewModels;
using MediatR;
using System.Linq;

namespace Angular2MultiSPA.Api
{
    internal class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {
        private ApplicationUser user;

        public GetAllCategoriesQuery(ApplicationUser user)
        {
            this.user = user;
            //var categories = _context.Categories.Select(a => new Category
            //{
            //    Id = a.CategoryId,
            //    Name = a.CategoryName,
            //    Description = a.Description,
            //    Image = a.Picture.ConvertToBase64()
            //});
            //this.categories = new List<Category>();
            

        }
    }

    public class GetAllCagegoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        public IEnumerable<Category> Handle(GetAllCategoriesQuery message)
        {
            if (message.User == null)
                return Enumerable.Empty<Category>();

            return [] {
                new Category() { };
            };
        }
    }
}

 
//public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<Address>>
//{
//    public IEnumerable<Address> Handle(GetAllAddressesQuery message)
//    {
//        if (message.User == null)
//            return Enumerable.Empty<Address>();

//        return [] {
//            new Address { Line1 = "34 Home Road", PostCode = "BY2 9AX" }
//        };
//    }
//}
