# MaintenanceGenerator

This is C# code generator from templates, you can create your own and custom templates to create a new generator. it is highly customizable. and was built as a need for increasing productivity for some of my previous projects.

Original source code: https://bitbucket.org/EduardoSantana/maintenancegenerator/src/master/

### How to Generate a new Set of files:

1. Create your Entity file in the C# project located in: `aspnet-core/src/YOUR_PROJECT_NAME.Core/Models`, where you have to add your own Project Name, which for me it is: `aspnet-core/src/AspnetBoilerPlate.Core/Models`. The example of my C# class is down below.

2. Execute the following command line, to view the files to be created:

```bash

YOUR_PROJECT_DIRECTORY="/Users/eduardosantana/source/AspnetBoilerPlate/8.1.0"
YOUR_PROJECT_NAME="AspnetBoilerPlate"
YOUR_ENTITY_LOWERCASE="place"
YOUR_TAG="v20230826_1319"

docker run --rm \
    -v $YOUR_PROJECT_DIRECTORY:/src \
    ghcr.io/eduardosantanaseverino/mg:$YOUR_TAG \
    --projectName $YOUR_PROJECT_NAME \
    --entity $YOUR_ENTITY_LOWERCASE

```

3. Execute the following command line, to create files:

```bash

YOUR_PROJECT_DIRECTORY="/Users/eduardosantana/source/AspnetBoilerPlate/8.1.0"
YOUR_PROJECT_NAME="AspnetBoilerPlate"
YOUR_ENTITY_LOWERCASE="place"
YOUR_TAG="v20230826_1319"

docker run --rm \
    -v $YOUR_PROJECT_DIRECTORY:/src \
    ghcr.io/eduardosantanaseverino/mg:$YOUR_TAG \
    --projectName $YOUR_PROJECT_NAME \
    --entity $YOUR_ENTITY_LOWERCASE \
    --save

```

### Notes:

Example of my entity in C#:

```csharp

using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace AspnetBoilerPlate.Models;

public class Place : FullAuditedEntity<int>, IPassivable
{
    public Place()
    {
        this.IsActive = true;
        this.CreationTime = DateTime.Now;
    }
    public string DefaultValue { get; set; }

    public bool IsReadOnly { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

}

```

### Build from source:

`docker build -t mg:v1 .`
