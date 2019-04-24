﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hurtowniaZegarkow
{
    class SellectManager
    {
        public string selectAdmin = "SELECT imie,nazwisko FROM admin;";
        public string selectClientsList = "SELECT *FROM klienci";
        public string selectModelsList = "SELECT * FROM modele";
        public string selectProducentList = "SELECT * FROM producenci";
        public string innerJoinZamdoProd = "SELECT * FROM producenci INNER JOIN zam_do_prod on producenci.idproducenta=zam_do_prod.idproducenta INNER JOIN modele on zam_do_prod.idmodelu=modele.idmodelu GROUP By producenci.idproducenta";

        public string connection = "datasource=127.0.0.1;port=3306;username=root;password=;persistsecurityinfo=True;database=czas";

        //INSERTY

        public string insertClientList(string firstnameClient, string surnameClient, string phonenumberClient, string emailClient, string companyClient, string discount)
        {
            return "INSERT INTO `klienci` (`idklienta`, `imie`, `nazwisko`, `nrtelefonu`, `email`, `firma`, `rabat`) VALUES (NULL, '" + firstnameClient + "', '"+ surnameClient + "', '"+ phonenumberClient + "', '"+ emailClient + "', '"+ companyClient + "', '"+ discount + "');";
        }

        public string insertModelList(string refModel,string brandmodel,string modelModel,string priceModel, string howManyModel)
        {
            return "INSERT INTO `modele` (`idmodelu`, `ref`, `marka`, `model`, `cena`, `iloscnastanie`) VALUES (NULL, '"+ refModel + "', '"+ brandmodel + "', '"+ modelModel + "', '"+priceModel+"', '"+howManyModel+"');";
        }

        public string insertProducentList(string branproducent,string countryProducent,string seatProducent,string phoneNumberProducent,string emailproducent)
        {
            return "INSERT INTO `producenci` (`idproducenta`, `marka`, `kraj`, `siedziba`, `telefon`, `email`) VALUES (NULL, '"+ branproducent + "', '"+ countryProducent+"', '"+ seatProducent + "', '"+ phoneNumberProducent + "', '"+ emailproducent + "');";
        }

    }
}