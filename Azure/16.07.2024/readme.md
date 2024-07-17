AZURE STORAGE:
            BLOB   - Large amount of unstructured data(images,videos,source code)
            [Similar to s3 in aws]
            TABLES -handling structured and semi structured data
            QUEUES -when handling mutliple requests we will store it in a queue
                   -we can add messages in the queues  
            [Similar to sqs in aws]
            FILES  -When one file is accessed by many VMs,backup is required for this
                   -when single pod is accessed by  volumes[ebs]
                   -when many pods are accessed by volumes[efs]
            [Similar to efs in aws]
--We can alsoperformstatic web hosting in storage acc-->data management-->static websites

Alternatives for cretaing resources without CLI:
    Azure CLI
    Terraform
    ARM Templates

https://learn.microsoft.com/en-us/cli/azure/reference-docs-index
AZURE CLI:
        When we want to quickly check the resources ,so we move to automation as it saves time

        #login
        1. az login

        #creating resource group 
        2. az group create --name demoResourceGroup --location westus2 

        #to list all existing groups
        3.az group list

        #to get one specific group
        4.az group show --name exampleGroup

        #create virtual machine
        vmname="myVM"
        username="azureuser"
        az vm create --resource-group $resourcegroup --name $vmname --image Win2022AzureEditionCore --public-ip-sku Standard --admin-username $username
        
        #to delete the group
        az group delete --name rgSubha