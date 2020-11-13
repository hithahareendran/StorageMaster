


* Introduction
------------
The warehouse management project, support products, storing products, 
and vehicles for transporting products from one storage to another. 
The project consist of entity classes and a controller,
which manages the interaction between the storage, vehicles and products 
and print out the output.

******************************************************************



* Requirements / Installation
------------

This module requires the following modules:

****Visual studio***** https://visualstudio.microsoft.com  
  
alt. 

***** dotnet***** https://dotnet.microsoft.com/



* Recommended modules
 ---------------------

This module requires an input:
Please paste this input in terminal, after running.

..... INPUT ..... TEST 1 ......
****************************************************
RegisterStorage DistributionCenter SofiaDistribution
RegisterStorage Warehouse AmazonWarehouse
AddProduct Gpu 1200
AddProduct SolidStateDrive 205
AddProduct HardDrive 70
AddProduct HardDrive 120
SelectVehicle SofiaDistribution 0
LoadVehicle HardDrive Gpu
SendVehicleTo SofiaDistribution 0 AmazonWarehouse
UnloadVehicle AmazonWarehouse 3
END
*****************************************************
..... INPUT 2 ..... TEST 2 ......
****************************************************
AddProduct HardDrive -20
RegisterStorage InvalidStorage LoshHackerStorage
RegisterStorage Warehouse GoodHackerStorage
SelectVehicle GoodHackerStorage 0
LoadVehicle HardDrive
SendVehicleTo LoshHackerStorage 0 GoodHackerStorage
SendVehicleTo GoodHackerStorage 0 LoshHackerStorage
END
*****************************************************

..... INPUT 3 ..... TEST 3 ......
****************************************************
RegisterStorage DistributionCenter AmazonDistribution
RegisterStorage Warehouse AmazonWarehouse
AddProduct HardDrive 80
AddProduct HardDrive 70
AddProduct HardDrive 120
AddProduct Gpu 800
SelectVehicle AmazonDistribution 0
LoadVehicle SolidStateDrive
LoadVehicle HardDrive Gpu HardDrive
SendVehicleTo AmazonDistribution 0 AmazonWarehouse
GetStorageStatus AmazonWarehouse
UnloadVehicle AmazonWarehouse 3
GetStorageStatus AmazonWarehouse
END
*****************************************************
 


 * Troubleshooting
-------------------
* If the menu does not display, check the following:

- Are you standing on StartUp.cs
- Did you press on run to start the app
- Did you feed the input given above. one at a time.


 * Maintainers
----------------
Current maintainers:

 * Anette Kniberg
 * Hitha Hareendran
 * Sobhi Malak
