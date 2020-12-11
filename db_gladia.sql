create database if not exists db_asp;
use db_asp;

 Create Table if not exists tbl_user (
    user_id int primary key auto_increment ,
    user_name varchar(80) Not null,
    user_email varchar(80) Not null,
    user_password varchar(80) Not null,
    user_img varchar(255),
    user_lvl varchar(2) Not null
 );
 
 Create table if not exists tbl_category(
	category_id int primary key auto_increment,  
    category_name varchar(50)
 );
 
 Create Table if not exists tbl_product (
    prod_id int primary key auto_increment ,
    prod_name varchar(80) Not null,
    prod_desc varchar(200) Not null,
    prod_brand varchar(80) Not null,
    prod_price varchar(255) Not null,
    prod_quant int not null,
	prod_img varchar(255),
    prod_min_quant int,
    fk_category int
 );
 
  Create Table if not exists tbl_pet (
    pet_id int primary key auto_increment ,
    pet_name varchar(80) Not null,
    pet_owner varchar(80) Not null,
    pet_tell varchar(80) Not null,
    pet_size varchar(50) Not null,
    pet_desc varchar (100)
 );
 
  Create Table if not exists tbl_agenda (
    agenda_id int primary key auto_increment ,
    agenda_date varchar(80) Not null,
    agenda_cli varchar(80) Not null,
    agenda_hour varchar(80) Not null,
    agenda_desc varchar(40) not null,
    fk_pet_id int not null
 );
 
 create table if not exists tbl_pos(
	pos_id int primary key auto_increment,
    pos_quant_order int,
    fk_product_id int
 );

SELECT left(agenda_date,10) as agenda_date,agenda_id, tbl_pet.pet_name, agenda_cli,right(agenda_hour,8) as agenda_hour,agenda_desc FROM db_asp.tbl_agenda 
join tbl_pet where tbl_pet.pet_id = fk_pet_id ;

 create view img 
 as SELECT REPLACE(user_img, "~/", "../"),user_id from tbl_user;
 
 create view Allproduct 
 as SELECT prod_id,prod_name,prod_desc,prod_brand,prod_price,prod_quant,prod_min_quant,fk_category,category_id,category_name,
 REPLACE(prod_img, "~/", "../") as img
 FROM db_asp.tbl_product 
 join tbl_category
 on tbl_product.fk_category = tbl_category.category_id;
 
 create view Pos 
 as SELECT pos.fk_product_id,prod.prod_name,prod.prod_price,pos.pos_quant_order,pos.pos_id FROM tbl_pos as pos
join tbl_product as prod
on pos.fk_product_id = prod.prod_id;

ALTER TABLE tbl_product
ADD FOREIGN KEY (fk_category) REFERENCES tbl_category (category_id);

ALTER TABLE tbl_agenda
ADD FOREIGN KEY (fk_pet_id) REFERENCES tbl_pet(pet_id);

INSERT INTO `db_asp`.`tbl_user` (`user_name`, `user_email`, `user_password`, `user_img`, `user_lvl`) VALUES ('Carlos Almeida', 'carlos@gmail.com', 'Carlos00', '~/Images/acf0d438-ebe6-4af8-bb62-bf08a5d59592_2.jpg', '1');

INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Comida');

INSERT INTO `db_asp`.`tbl_product` (`prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('Ração Golden Fórmula Light para Cães Adultos - 15kg', 'Linha: Premium', 'Golden', '134', '100', '~/Images/de1f8195-25d8-4760-adf9-e9cf9df2ad42_racao.jpg', '20', '1');

-- TRUNCATE TABLE tbl_pos;

-- drop database db_asp;
-- drop table tbl_product;
-- drop user 'gladia'@'localhost';

CREATE USER 'gladia'@'localhost' IDENTIFIED BY '123456';
GRANT ALL PRIVILEGES ON db_asp.* TO 'gladia'@'localhost' WITH GRANT OPTION;