﻿using Shop.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Product
{
    public class ProductModel : BaseEntity
    {
        public ProductModel(string name, int categoryId, string description, string exteraDescription, string mainPicture)
        {
            Name = name; 
            CategoryId = categoryId; 
            Description = description; 
            ExteraDescription = exteraDescription; 
            MainPicture = mainPicture;
        }

        public void Edit(string name, int categoryId, string description, string exteraDescription, string mainPicture)
        {
            Name = name;
            CategoryId = categoryId;
            Description = description;
            ExteraDescription = exteraDescription;
            MainPicture = mainPicture;
        }

        public string Name { get; private set; }
        public int CategoryId { get; private set;}
        public string Description { get; private set; }
        public string ExteraDescription { get; private set; }
        public string MainPicture { get; private set; }
        public CategoryModel Category { get; private set; }
        public List<ProductPropertyModel> ProductProperties { get; private set; }
        public List<ProductCommentModel> ProductComments { get; private set; }
        public List<ProductPictureModel> ProductPictures { get; private set; }
    }
}
