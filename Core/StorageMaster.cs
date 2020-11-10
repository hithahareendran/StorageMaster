using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagement.Core
{
    class StorageMaster :IStorageMaster
    {
        private IProductFactory productFactory;
        private IProductRepository productRepository;
        private IStorageFactory storageFactory;
        private IStorageRepository storageRepository;
        private IVehicle currentVehicle;

        public StorageMaster(IProductFactory productFactory, 
            IProductRepository productRepository, IStorageFactory storageFactory,
            IStorageRepository storageRepository)
        {
            this.productFactory = productFactory;
            this.productRepository = productRepository;
            this.storageFactory = storageFactory;
            this.storageRepository = storageRepository;
            this.currentVehicle = null;
        }


    }

}
