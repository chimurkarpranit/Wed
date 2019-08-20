namespace Day5_8
{
    public class AllMessage
    {
        public string strEmpCheck = "select EmployeeID from Employees where EmployeeID='";
        public string strTerrCheck = "select TerritoryID from Territories where TerritoryID='";
        public string strEmpTerCheck = "select EmployeeID,TerritoryID from EmployeeTerritories WHERE EmployeeID='";
        public string strInsertEmpTer = "SET FOREIGN_KEY_CHECKS = 0; insert into EmployeeTerritories (EmployeeID,TerritoryID) values ('";
        public string strInsertTer = "insert into territories (TerritoryID, TerritoryDescription, RegionID) values ('";
        public string strInsertInEmpTer = "insert into employeeterritories (EmployeeID, TerritoryID) values ('";
        public string strCustomer = "select CustomerID,Companyname,City,Country from customers";
        public string strUpCustomer = "SET FOREIGN_KEY_CHECKS = 0; update customers set CompanyName='";
        public string strDelCustomer = "SET FOREIGN_KEY_CHECKS = 0; delete FROM customers where CustomerID= '";
        public string strInsCustomer = "INSERT INTO customers(CustomerID, CompanyName, City, Country ) VALUES ( ";
        public string strEmTer = "select * from employeeterritories";
        public string strEmTerDel = "delete from employeeterritories where TerritoryID = '";
        public string strTerDel = "delete from territories where TerritoryID= '";
        public string strEmTerCheck = "select EmployeeID, TerritoryID from employeeterritories where EmployeeID='";
        public string strEmTerUpdate = "SET FOREIGN_KEY_CHECKS = 0; update employeeterritories set EmployeeID='";
        public string strUpdate1 = "update employeeterritories set TerritoryID= '";
        public string strUpdate2 = "update territories set Territories= '";
        public string strEmTerInsert = "SET FOREIGN_KEY_CHECKS = 0; INSERT INTO employeeterritories(EmployeeID, TerritoryID) VALUES ( '";
        public string strInsertTerritory = "INSERT INTO territories(TerritoryID, TerritoryDescription, RegionID) VALUES( '";
        public string strTerInEmCheck = "select TerritoryID from EmployeeTerritories where TerritoryID= '";
    }
}