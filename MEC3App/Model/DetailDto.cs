using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static MEC3App.Model.DetailApiModel;

namespace MEC3App.Model
{
    public class DetailDto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DetailID { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public ObservableCollection<DetailProductDto> Products { get; set; }

        public ObservableCollection<String> Products2{ get; set; }

    public DetailDto()
        {

        }

        public DetailDto(string name, int iD, string image, string description, ObservableCollection<DetailProductDto> products)
        {
            Name = name;
            DetailID = iD;
            Image = image;
            Description = description;
            Products = products;
        }

        public DetailDto(string name, int iD, string image, string description, ObservableCollection<String> products)
        {
            Name = name;
            DetailID = iD;
            Image = image;
            Description = description;
            Products2 = products;
        }

    }
}
