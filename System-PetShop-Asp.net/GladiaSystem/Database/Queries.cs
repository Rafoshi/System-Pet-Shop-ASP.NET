using MySql.Data.MySqlClient;
using System;
using GladiaSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace GladiaSystem.Database
{
    public class Queries
    {
        Connection con = new Connection();

        public bool CategoryExists(Category category)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_category WHERE category_name = @name", con.ConnectionDB());
            cmd.Parameters.AddWithValue("@name", category.name);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public string Login(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_lvl FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.userLvl = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.userLvl;
                    }
                }
            }
            else
            {
                user.userLvl = null;
            }
            reader.Close();
            return "error";
        }

        public string GetUserName(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_name FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.name = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.name;
                    }
                }
            }
            else
            {
                user.userLvl = null;
                reader.Close();
                return "error";
            }
            reader.Close();
            return "error";
        }

        public string GetUserEmail(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_email FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.email = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.email;
                    }
                }
            }
            else
            {
                user.userLvl = null;
                reader.Close();
                return "error";
            }
            reader.Close();
            return "error";
        }

        public string GetUserID(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_id FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.userID = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.userID;
                    }
                }
            }
            else
            {
                user.userLvl = null;
                reader.Close();
                return "error";
            }
            reader.Close();
            return "error";
        }   

        public string GetUserImages(string UserID)
        {
            MySqlCommand cmd = new MySqlCommand("select * from img  where user_id = @UserID;", con.ConnectionDB());
            cmd.Parameters.Add("@UserID", MySqlDbType.VarChar).Value = UserID;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.img = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.img;
                    }
                }
            }
            else
            {
                return null;
            }
            reader.Close();
            return "error";

        }

        public void ChangePhoto(string imagePath, string session)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_user` SET `user_img` = @img WHERE (`user_id` = @session);", con.ConnectionDB());
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = imagePath;
            cmd.Parameters.Add("@session", MySqlDbType.VarChar).Value = session;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void RegisterCategory(Category category)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES (@name);", con.ConnectionDB());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = category.name;
          
            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }
        
        public void RegisterProd(Product product, string path)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_product` (`prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES(@Name, @Desc, @Brand, @Price, @Quant, @Img, @QuantMin, @CategoryID);", con.ConnectionDB());
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = product.Name;
            cmd.Parameters.Add("@Desc", MySqlDbType.VarChar).Value = product.Desc;
            cmd.Parameters.Add("@Brand", MySqlDbType.VarChar).Value = product.Brand;
            cmd.Parameters.Add("@Price", MySqlDbType.VarChar).Value = product.Price;
            cmd.Parameters.Add("@Quant", MySqlDbType.VarChar).Value = product.Quant;
            cmd.Parameters.Add("@Img", MySqlDbType.VarChar).Value = path;
            cmd.Parameters.Add("@QuantMin", MySqlDbType.VarChar).Value = product.QuantMin;
            cmd.Parameters.Add("@CategoryID", MySqlDbType.VarChar).Value = product.Category.ID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void RegisterPet(Pet pet)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_pet` (`pet_name`, `pet_owner`, `pet_tell`, `pet_size`, `pet_desc`) VALUES (@Name, @Owner, @Tel , @Size, @Desc);", con.ConnectionDB());
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = pet.Name;
            cmd.Parameters.Add("@Owner", MySqlDbType.VarChar).Value = pet.Owner;
            cmd.Parameters.Add("@Tel", MySqlDbType.VarChar).Value = pet.Tel;
            cmd.Parameters.Add("@Size", MySqlDbType.VarChar).Value = pet.Size;
            cmd.Parameters.Add("@Desc", MySqlDbType.VarChar).Value = pet.Desc;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public void RegisterEmployee(User employee, string path)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_user` (`user_name`, `user_email`, `user_password`, `user_img`, `user_lvl`) VALUES(@name, @email, @password, @img, '0');", con.ConnectionDB());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = employee.name;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = employee.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = employee.password;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = path;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void RegisterAdm(User adm, string path)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_user` (`user_name`, `user_email`, `user_password`, `user_img`, `user_lvl`) VALUES(@name, @email, @password, @img, '1');", con.ConnectionDB());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = adm.name;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = adm.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = adm.password;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = path;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void RegisterAgenda(Agenda agenda)
        {
            DateTime actualTime = DateTime.Now;
            if (actualTime < agenda.Day)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_agenda` (`agenda_date`, `agenda_cli`, `agenda_hour`, `agenda_desc`, `fk_pet_id`) VALUES (@day, @nameCli, @hour, @desc, @petID);", con.ConnectionDB());
                cmd.Parameters.Add("@nameCli", MySqlDbType.VarChar).Value = agenda.ClientName;
                cmd.Parameters.Add("@petID", MySqlDbType.VarChar).Value = agenda.Pet.ID;
                cmd.Parameters.Add("@day", MySqlDbType.VarChar).Value = agenda.Day;
                cmd.Parameters.Add("@hour", MySqlDbType.VarChar).Value = agenda.Hour;
                cmd.Parameters.Add("@desc", MySqlDbType.VarChar).Value = agenda.DescAgenda;

                cmd.ExecuteNonQuery();
                con.DisconnectDB();
            }
        }

        public void DeleteAccount(string deleteID)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `db_asp`.`tbl_user` WHERE (`user_id` = @user_id );", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = deleteID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void ChangePass(string password, string userID)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_user` SET `user_password` = @password WHERE (`user_id` = @user_id);", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = userID;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public void ChangeName(string name, string userID)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_user` SET `user_name` = @name WHERE (`user_id` = @user_id);", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = userID;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public void DeleteItemAgenda(int codItem)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `db_asp`.`tbl_agenda` WHERE (`agenda_id` = @codAgenda);", con.ConnectionDB());
            cmd.Parameters.Add("@codAgenda", MySqlDbType.VarChar).Value = codItem;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void DeletePos(int codPos)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `db_asp`.`tbl_pos` WHERE (`pos_id` = @codPos);", con.ConnectionDB());
            cmd.Parameters.Add("@codPos", MySqlDbType.VarChar).Value = codPos;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void DeleteItemProduct(int codItem)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `db_asp`.`tbl_product` WHERE (`prod_id` = @codAgenda);", con.ConnectionDB());
            cmd.Parameters.Add("@codAgenda", MySqlDbType.VarChar).Value = codItem;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public Pet GetPet(string petName)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT pet_name, pet_owner, pet_tell, pet_size, pet_desc FROM db_asp.tbl_pet; ", con.ConnectionDB());
            cmd.Parameters.Add("@itemName", MySqlDbType.VarChar).Value = petName;

            MySqlDataReader reader;


            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Pet dto = new Pet();
                    {
                        dto.Name = Convert.ToString(reader[0]);
                        dto.Owner = Convert.ToString(reader[1]);
                        dto.Tel = Convert.ToString(reader[2]);
                        dto.Size = Convert.ToString(reader[3]);
                        dto.Desc = Convert.ToString(reader[4]);

                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();
            Pet a = new Pet();
            return a;
        }

        public Product GetProduct(string productName)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT prod_id,prod_name,prod_desc,prod_brand,prod_price,prod_quant,prod_min_quant,fk_category,category_id,category_name, REPLACE(prod_img, '~/', '../') FROM db_asp.tbl_product join tbl_category on tbl_product.fk_category = tbl_category.category_id WHERE prod_name LIKE @name;", con.ConnectionDB());
            string name = productName + "%";
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product dto = new Product();
                    {
                        dto.ID = Convert.ToInt32(reader[0]);
                        dto.Name = Convert.ToString(reader[1]);
                        dto.Desc = Convert.ToString(reader[2]);
                        dto.Brand = Convert.ToString(reader[3]);
                        dto.Price = Convert.ToInt32(reader[4]);
                        dto.Quant = Convert.ToInt32(reader[5]);
                        dto.QuantMin = Convert.ToInt32(reader[6]);
                        dto.Category.name = Convert.ToString(reader[9]);
                        dto.img = Convert.ToString(reader[10]);
                        reader.Close();
                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();
            Product a = new Product();
            return a;
        }

        public void AddProduct(Pos pos)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_pos` (`pos_quant_order`, `fk_product_id`) VALUES (@quantOrder, @prodId);", con.ConnectionDB());
            cmd.Parameters.Add("@quantOrder", MySqlDbType.VarChar).Value = pos.QuantOrder;

            cmd.Parameters.Add("@prodId", MySqlDbType.VarChar).Value = getProdId(pos.Product.Name);

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void Finish()
        {
            MySqlCommand cmd = new MySqlCommand("use db_asp;TRUNCATE TABLE tbl_pos;", con.ConnectionDB());

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public int Administrator()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS 'Administrator' FROM db_asp.tbl_user WHERE user_lvl = 1;", con.ConnectionDB());

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int outPut = Convert.ToInt32(reader[0]);
                    reader.Close();
                    return outPut;
                }
            }
            reader.Close();
            return 0;
        }

        public int CommonUser()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS 'CommonUser' FROM db_asp.tbl_user WHERE user_lvl = 0;", con.ConnectionDB());

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int outPut = Convert.ToInt32(reader[0]);
                    reader.Close();
                    return outPut;
                }
            }
            reader.Close();
            return 0;
        }

        public int getProdId(string name)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT prod_id FROM db_asp.tbl_product WHERE prod_name LIKE @prodName;", con.ConnectionDB());
            string nameProduct = name + "%";
            cmd.Parameters.Add("@prodName", MySqlDbType.VarChar).Value = nameProduct;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product dto = new Product();
                    {
                        dto.ID = Convert.ToInt32(reader[0]);
                        int id = dto.ID;
                        reader.Close();
                        return id;
                    }
                }
            }
            reader.Close();
            return 0;
        }

        public int SmallPort() {
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) as SmallPort FROM db_asp.tbl_pet where pet_size = 'Pequeno';", con.ConnectionDB());

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int outPut = Convert.ToInt32(reader[0]);
                    reader.Close();
                    return outPut;
                }
            }
            reader.Close();
            return 0;
        }

        public int MediumPort()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) as SmallPort FROM db_asp.tbl_pet where pet_size = 'Medio';", con.ConnectionDB());

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int outPut = Convert.ToInt32(reader[0]);
                    reader.Close();
                    return outPut;
                }
            }
            reader.Close();
            return 0;
        }

        public int LargePort()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) as SmallPort FROM db_asp.tbl_pet where pet_size = 'Grande';", con.ConnectionDB());

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int outPut = Convert.ToInt32(reader[0]);
                    reader.Close();
                    return outPut;
                }
            }
            reader.Close();
            return 0;
        }

        public List<Product> ListCategoryQuant()
        {
            MySqlCommand cmd = new MySqlCommand("select sum(prod_quant) as quant, category_name from db_asp.tbl_product inner join tbl_category on tbl_product.fk_category = tbl_category.category_id group by category_name;", con.ConnectionDB());
            var categoryData = cmd.ExecuteReader();
            return ListAllCategoryQuant(categoryData);
        }

        private List<Product> ListAllCategoryQuant(MySqlDataReader categoryData)
        {
            var AllCategoryQuant = new List<Product>();

            while (categoryData.Read())
            {
                var tempCategoryQuant = new Product()
                {
                    Quant = int.Parse(categoryData["quant"].ToString()),
                    CategoryName = categoryData["category_name"].ToString(),
                };
                AllCategoryQuant.Add(tempCategoryQuant);
            }
            categoryData.Close();
            return AllCategoryQuant;
        }

        public List<Category> ListCategory()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT category_name,category_id FROM db_asp.tbl_category;", con.ConnectionDB());
            var categoryData = cmd.ExecuteReader();
            return ListAllCategory(categoryData);
        }

        private List<Category> ListAllCategory(MySqlDataReader categoryData)
        {
            var AllCategory = new List<Category>();
           
            while (categoryData.Read())
            {
                var tempCategory = new Category()
                {
                    name = categoryData["category_name"].ToString(),
                    ID = int.Parse(categoryData["category_id"].ToString()),
                };
                AllCategory.Add(tempCategory);
            }
            categoryData.Close();
            return AllCategory;
        }

        public List<Pet> ListPet()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT pet_name,pet_id,pet_owner FROM db_asp.tbl_pet;", con.ConnectionDB());
            var categoryPet = cmd.ExecuteReader();
            return ListAllPet(categoryPet);
        }

        private List<Pet> ListAllPet(MySqlDataReader categoryPet)
        {
            var AllPet = new List<Pet>();

            while (categoryPet.Read())
            {
                var tempPet = new Pet()
                {
                    Name = categoryPet["pet_name"].ToString(),
                    ID = int.Parse(categoryPet["pet_id"].ToString()),
                };
                AllPet.Add(tempPet);
            }
            categoryPet.Close();
            return AllPet;
        }

        public List<Product> ListProduct()
        {
            MySqlCommand cmd = new MySqlCommand("select * from allproduct", con.ConnectionDB());
            var ProductDatas = cmd.ExecuteReader();
            return ListAllProduct(ProductDatas);
        }

        public List<Product> ListAllProduct(MySqlDataReader dt)
        {
            var AllProduct = new List<Product>();
            while (dt.Read())
            {
                var ProdTemp = new Product()
                {
                    ID = int.Parse(dt["prod_id"].ToString()),
                    Name = (dt["prod_name"].ToString()),
                    Desc = (dt["prod_desc"].ToString()),
                    Price = int.Parse(dt["prod_price"].ToString()),
                    Quant = int.Parse(dt["prod_quant"].ToString()),
                    QuantMin = int.Parse(dt["prod_min_quant"].ToString()),
                    Brand = (dt["prod_brand"].ToString()),
                    img = (dt["img"].ToString()),
                };
                AllProduct.Add(ProdTemp);
            }
            dt.Close();
            return AllProduct;
        }

        public  List<Pos> ListPos()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM db_asp.pos;", con.ConnectionDB());
            var PosDatas = cmd.ExecuteReader();
            return ListAllPos(PosDatas);
        }

        public List<Pos> ListAllPos(MySqlDataReader dt)
        {
            var AllPos = new List<Pos>();
            while (dt.Read())
            {
                var PosTemp = new Pos()
                {
                    QuantOrder = int.Parse(dt["pos_quant_order"].ToString()),
                    ProdID = int.Parse(dt["fk_product_id"].ToString()),
                    ProdName = dt["prod_name"].ToString(),
                    ProdPrice = int.Parse(dt["prod_price"].ToString()),
                    ID = int.Parse(dt["pos_id"].ToString()),
                };
                AllPos.Add(PosTemp);
            }
            dt.Close();
            return AllPos;
        }

        public List<Agenda> ListAgenda()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT left(agenda_date,10) as agenda_date,agenda_id, tbl_pet.pet_name, agenda_cli,right(agenda_hour,8) as agenda_hour,agenda_desc FROM db_asp.tbl_agenda join tbl_pet where tbl_pet.pet_id = fk_pet_id ;", con.ConnectionDB());
            var DadosAlunos = cmd.ExecuteReader();
            return ListAllAgenda(DadosAlunos);
        }

        public List<Agenda> ListAllAgenda(MySqlDataReader dt)
        {
            var AllAgenda = new List<Agenda>();
            while (dt.Read())
            {
                var AlunoTemp = new Agenda()
                {
                    ID = int.Parse(dt["agenda_id"].ToString()),
                    ClientName = dt["agenda_cli"].ToString(),
                    ShowName = dt["pet_name"].ToString(),
                    Day = DateTime.Parse(dt["agenda_date"].ToString()),
                    Hour = DateTime.Parse(dt["agenda_hour"].ToString()),
                    DescAgenda = dt["agenda_desc"].ToString(),
                };
                AllAgenda.Add(AlunoTemp);
            }
            dt.Close();
            return AllAgenda;
        }
    }
}