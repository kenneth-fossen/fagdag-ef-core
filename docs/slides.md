---
# You can also start simply with 'default'
theme: dracula
# random image from a curated Unsplash collection by Anthony
# like them? see https://unsplash.com/collections/94734566/slidev
background: https://cover.sli.dev
# some information about your slides (markdown enabled)
title: Fagdag - .NET EF Core Essentials
info: |
  ## Fagdag: .NET EF Core Essentials
   
# apply unocss classes to the current slide
class: text-center
# https://sli.dev/features/drawing
drawings:
  persist: false
# slide transition: https://sli.dev/guide/animations.html#slide-transitions
transition: slide-left
# enable MDC Syntax: https://sli.dev/features/mdc
mdc: true
---

# Fagdag: .NET EF Core Essentials

Presentation slides for developers

<div @click="$slidev.nav.next" class="mt-12 py-1" hover:bg="white op-10">
  Press Space for next page <carbon:arrow-right />
</div>

<div class="abs-br m-6 text-xl">
  <button @click="$slidev.nav.openInEditor" title="Open in Editor" class="slidev-icon-btn">
    <carbon:edit />
  </button>
  <a href="https://github.com/slidevjs/slidev" target="_blank" class="slidev-icon-btn">
    <carbon:logo-github />
  </a>
</div>

---
layout: center
---

# Repository

[https://github.com/kenneth-fossen/fagdag-ef-core](https://github.com/kenneth-fossen/fagdag-ef-core)

Select `Use this template` -> `Create new Repo`

---

# Todays Topics

<v-clicks> 

- Introduction to EF Core
- Short overview:
  - 5 -> 6 -> 7 -> 8 -> 9
- Theory and Practice
- Task: DbContext Configuration & Modeling
- Task: Migrations
- Task: Seeding
- Task: Querying
- Task: Exploring

</v-clicks>

---
layout: image-right
transition: fade-out
image: ./assets/kbo.jpg
---
# $ whoami
```hs {1|2-5|6-9|10-12|all}
$ whoami
{
     name: Kenneth Fossen,
     dep: Dragefjellet@Bouvet,
     email: kenneth.fossen@bouvet.no,
     edu: [
         Bachelor i Datatryggleik
         Master i Programvare Utvikling
     ],
     current: [
          project: {
              name: CommonLibrary@Equinor
          },
          Software Developer,
          Security Champion,
          #rustaceans, #bergen-labben, #boffvet
      ],
      hobbies: [
        "dogs",
        "reading",
        "ultra-running"
      ]
 }
```
---
layout: center
---

# What are your expectations?

---

# What is EF Core

EF Core *can* serve as a object-relational-mapper (O/RM)

<v-clicks>

- Enabling .NET developers to work with a database using .NET Objects
- Eliminates the need for most of the data-access code that typically need to be written.
- It gives you migrations that allow evolving the database as the model changes.

</v-clicks>

---
layout: two-cols
title: "EF vs EF Core"
hideInToc: true
---
::default::
# EF

<v-clicks>

- EF6 is a ORM for .NET Framework
- Supports also .NET Core
- No longer developed

</v-clicks>

::right::
# EF Core

<v-clicks>

- EF Core is modern ORM for .NET
- Support for LINQ
- Change Tracking
- Updates
- Schema Migrations

</v-clicks>

<!--
	EF6 is a object-relational mapper desined fro .NET Framework, but with support for .NET Core.
  This is no longer actively developed.

  EF Core is the modern object-database mapper for .NET
  Support for LINQ queries, change tracking, updates, and schema migrations.
-->


---
layout: two-cols-header
---

### DbContext : Example C# Code

```ts {all|8-13}
public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfigure(DbContextOptionsBuilder o) {
      o.UseSqlServer("connectionString");
    }
}
public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public int Rating { get; set; }
}
```

<div v-click="1">
  <Arrow x1="350" y1="300" x2="450" y2="350" />
</div>
::right::

### Database table

| BlogId | Url | Rating |
| --- | --- | --- |
| 1 | http://blog.kefo.no | 5 |

---

# LINQ to SQL

```ts {all|2|4-5,11-12|6,13|7,14|8|all}
// C# Code
using var db = new BloggingContext();

var blogs = db
    .Blogs
    .Where(b => b.Rating > 3)
    .OrderBy(b => b.Url)
    .ToList(); // Query and fetch data into memory

// SQL OUTPUT
SELECT a."BlogId", a."Url", a."Rating"
FROM "Blogs" as a
WHERE a."Rating" > 3
ORDER BY a."Url"
```

---
layout: iframe-right
url: https://dapperlib.github.io/Dapper/
---

# Alternative: Dapper

<v-clicks>

- A simple object mapper for .NET
- Know to be the fastest
- Low memory footprint (compared to EF Core)
- Complete control over your SQL Queries
- Goto solution when performance is critical

</v-clicks>

<!---
	It is a simple object mapper for .NET, know to be the fastest, and has the least memory overhead.

	You can write raw SQL parameterized queries.

  It give good performance and complete control over the queries, and is considered the goto solution when it is performance critical.
-->

---

# Short overview


<div class="gird-flow-row">
  <div class="col-span-2">
    <h2> 5 -> 6 -> 7 -> 8 -> 9</h2>
  </div>
  <img src="/assets/efcore.png" class="ml-100 mt-10 h-60">
</div>

---

# EF Core 5

<br>
<v-click>

  <p class="text-3xl"><mdi-alert class="text-yellow"/> Query Strategy Changed <mdi-alert class="text-yellow"/></p>

  - Performance
  - Complex Queries that was fast **may** be slow

</v-click>

<v-click>

Lets study this code

```ts {all|2|3|all}
var artists = context
    .Artists
    .Include(e => e.Albums)
    .ToList();
```

</v-click>

---
layout: two-cols
---
::default::
# Split Query

```sql
SELECT a."Id", a."Name"
FROM "Artists" AS a
ORDER BY a."Id"

SELECT a0."Id", a0."ArtistId", a0."Title", a."Id"
FROM "Artists" AS a
INNER JOIN "Album" AS a0 ON a."Id" = a0."ArtistId"
ORDER BY a."
```

::right::

# Combined Query

```sql
SELECT a."Id", a."Name",
       a0."Id", a0."ArtistId", a0."Title"
FROM "Artists" AS a
LEFT JOIN "Album" AS a0 ON a."Id" = a0."ArtistId"
ORDER BY a."Id", a0."Id"

```

---

# EF Core 6

<br>

<v-clicks>

- SQL Server temporal tables
- Migration Bundles
- Pre-convention model configuration
- Compiled models
- Performance
	- 70% better query performance than EF Core 5.0
	- 31% afaster executing untracked queries
	- Heap allocations have been reduced by 43%

</v-clicks>

<!--
- Pre-convention model configuration
	- You can configure default matppers for e.g. all string in a model/databasecontext.

Compiled models
 -	For databases with many relations, 100s to 1000s entity types and relationsships.
- 	The startup time until the first operation is done on the DbContext, may be more than expected, and Compiled models may helps in this case.

-->

---

# EF Core 7

<v-clicks>

- Faster `SaveChanges`
  - 4x times faster than EF Core 6
  - Has fewer roundtrips to the database when saving

- `Encrypt` defaults to `true` for SQL Server connections

Consequences, you need a **valid** certificate on the SQL Server.
The client must trust this certificate
2 ways to mitigate this:
  - `TrustServerCertificate=True`
  - `Encrypt=False`

</v-clicks>

---

# EF Core 8

<v-clicks>

- Close to Dapper Performance and Memory Consumption
- Raw SQL queries for unmapped types
- DateOnly/TimeOnly support for SQL Server

- `.Contains()` in LINQ queries may stop working on older SQL Server versions.
- Only supports SQL Server 2014 above

</v-clicks>

---

# EF Core 9

<v-clicks>

- `UseSeeding` is new
- `dotnet ef migrations has-pending-model-changes`
- `UseAzureSynapse()` or `UseAzureSql()`
- Complex types: `GroupBy` and `ExecuteUpdate`

</v-clicks>



---
layout: image-right
image: ./assets/boisy_kion.jpg
---

# PAUSE

---

# Task 1: Getting Ready

Ensuring everyone have:

- Installed .NET
- EF Core CLI tools
- Have the code
- Can build and run the project
- Explore the project in the IDE

---

# Task 2: Task: DbContext Configuration & Simple Modeling

- Create the model for `Events`

---

```ts {all|1|1-3|5-7|9-15|18-24}
public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfigure(DbContextOptionsBuilder o) {
      o.UseSqlServer("connectionString");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder
        .Entity<Blog>()
        .HasIndex(e => e.Name)
        .HasDatabaseName("IX_Names_Ascending");
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public int Rating { get; set; }
}
```

---

# EntityTypeConfigurationAttribute

```ts {0-11|13-16|all}
class TblSalesConfiguration : IEntityTypeConfiguration<TblSales>
{
    public void Configure(EntityTypeBuilder<TblSales> builder)
    {
        builder.ToTable("Sales");

        builder
            .HasIndex(t => t.Name)
            .IsUnique();
    }
}

// Inside DBContext
protected override void OnModelCreating(ModelBuilder modelBuilder) {
  new TblSalesConfiguration()
    .Configure(modelBuilder.Entity<TblSales>());
}
```

---

# Data annotations

Use data annotations to configure a model

```ts
[Table("Books")]
class Book {

  [Required]
  [MaxLength(100)]
  public string Title { get; set; }
}
```


---

# Modeling tips

Use Data Annotation to limit e.g. size of your types
e.g. `string`

```ts{1|1-4|1,6-7|9-10|all}
public string Name { get; set; }

// SQL produced
Name nvarchar(max) -- (2GB)

[StringLength(64)] // nvarchar(64)
public string Name { get; set; }

[MinLength(5), MaxLength(12)]
public string Password { get; set; }
```

---

# Task 3: Migrations & Database Update

- Usefull commands
- Create a inital migrations
- Apply the migration to the database
- Change the model


```shell
dotnet ef dbcontext info
dotnet ef migrations has-pending-model-changes
dotnet ef migrations list
```

---

# Task 4: Seeding

- Seed some data
- Install usefull library
- Be sure to have applied any migrations before seeding



---

# Task 5: Querying

- Implemeting the service for querying events
- Update the model and seeding the database with new data
- Implement a controller to handle requests for participants

<v-clicks>

- `.TagWith("Fetching all users)`
- `.Select()` does not need .AsNoTracking()
- Use `-Async` version of the operator e.g (`ToListAsync()`)
- `Select` to only fetch the right columns
- An Index will not be used if there are operations on a Column

</v-clicks>

---
layout: two-cols-header
---

# Querying: Deadly Sin

::left::
Casting `IQueryable` to `IEnumerable`
<br>

<v-clicks>

Examples
- `.ToList()`
- `.AsEnumerable()`

<p class="text-3xl"><mdi-alert class="text-yellow"/> Will fetch all the data! <mdi-alert class="text-yellow"/></p>

</v-clicks>

::right::

<v-click>

# Code Example

```ts {1-3|5-9|15-17|10-13|1,15|all}
public IEnumerable<Sales> GetSales() {
  return SalesDbContex.Sales;
}

public int CountSalesInDb() {
  return GetSales().Count();
  // SELECT * FROM Sales
  // in memory count the collection
}
public int CountSalesInDb2() {
  return GetSales2().Count();
  // SELECT COUNT(*) FROM Sales;
}

private IQueryable<Sale> GetSales2() {
   return SalesDbContext.Sales;
}
```

</v-click>

---

# Querying: Deadly Sin

## Not using `.AsNoTracking()`

If you are only reading from the database, there there is no need to track the entity.

<v-click>

<p>Perfomance <mdi-lightning-bolt class="text-2xl text-yellow" /></p>

- Can use ~4x **less** memory
- Can be ~5x **faster**

<p class="text-2xl"><mdi-alert class="text-yellow" /> Not for SQLite DB Provider <mdi-alert class="text-yellow" /></p>
</v-click>

---
layout: two-cols-header
---

# Querying: Deadly Sin

::left::

## Explicit Joins

`.Include(x => x.Customers)`

1. They are always included
2. We get all their columns
3. Forget to remove them

::right::

# Example

```ts {1-5|4|7-18|16-17|4|10-17|all}
var explicitQuery = _dbContext.Sales
    .AsNoTracking()
    .TagWithContext()
    .Include(x => x.SalesPerson)
    .Where(x => x.SalesPersonId == 1);

var implicitQuery = _dbContext.Sales
    .AsNoTracking()
    .Where(x => x.SalesPersonId == 1)
    .Select(x => new SalesWithSalesPerson {
        CustomerId = x.CustomerId,
        SalesId = x.SalesPersonId,
        ProductId = x.ProductId,
        Quantity = x.Quantity
        SalesPersonId = x.SalesPersonId,
        SalesPersonFirstName = x.SalesPerson.FirstName,
        SalesPersonLastName = x.SalesPersons.LastName
    });
```

---
layout: two-cols-header
hideInToc: true
---

# Querying: Deadly Sin

## Inefficient Updates and Deletes

`foreach` will generate `n` SQL statements

::left::

# `foreach`

```ts
foreach (var blog in context.Blogs.Where(b => b.Rating < 3))
{
    context.Blogs.Remove(blog);
}

context.SaveChanges();
```

::right::

# `.ExecuteDelete()`

```ts
context.Blogs
  .Where(b => b.Rating < 3)
  .ExecuteDelete();

// SQL
DELETE FROM [b]
FROM [Blogs] AS [b]
WHERE [b].[Rating] < 3
```


---

# Task 6: Exploring

- Context Pooling
- Change Database Provider
- Multiple Contexts
- Connection Resiliance