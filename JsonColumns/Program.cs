await using var context = new CustomerContext();
await context.InitializeDatabase();

// Console.WriteLine();
//
// await foreach (var customer in context.Customers.AsAsyncEnumerable())
// {
//     Console.WriteLine();
//     Console.WriteLine($"{customer.InformalName} lives in {customer.Contact.Address.City}");
//     foreach (var phone in customer.Contact.PhoneNumbers)
//     {
//         Console.WriteLine($"  {phone.Type} Phone: +{phone.CountryCode} {phone.Number}");
//     }
// }
//
// // .Where(customer => customer.Contact.Address.Country == "UK")
//
// Console.WriteLine();
//
// await foreach (var customer in context.Customers
//                    .AsNoTracking()
//                    .Where(customer => customer.Contact.Address.Country == "UK")
//                    .Select(customer => 
//                        new
//                        {
//                            Name = customer.InformalName,
//                            City = customer.Contact.Address.City,
//                            PhoneNumbers = customer.Contact.PhoneNumbers
//                        })
//                    .AsAsyncEnumerable())
// {
//     Console.WriteLine();
//     Console.WriteLine($"{customer.Name} lives in {customer.City}");
//     foreach (var phone in customer.PhoneNumbers)
//     {
//         Console.WriteLine($"  {phone.Type} Phone: +{phone.CountryCode} {phone.Number}");
//     }
// }

Console.WriteLine();

var alice = await context.Customers.SingleAsync(customer => customer.InformalName == "Alice");

alice.Contact.IsActive = false;
alice.Contact.Address.Street = "3 Main St";
alice.Contact.Address.Postcode = "CW1 5ZZ";

await context.SaveChangesAsync();
