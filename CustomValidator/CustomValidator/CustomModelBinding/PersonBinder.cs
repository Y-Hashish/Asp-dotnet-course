using CustomValidator.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomValidator.CustomModelBinding
{
    public class PersonBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var person = new Person();
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.Name = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

                if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
                {
                    person.Name += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }
            if (bindingContext.ValueProvider.GetValue("Name").Count() > 0)
            {
                person.Name =  bindingContext.
                    ValueProvider.GetValue("Name").FirstValue;
            }
            if (bindingContext.ValueProvider.GetValue("Date1").Count() > 0)
            {
                person.Date1 = Convert.ToDateTime( bindingContext.
                    ValueProvider.GetValue("Date1").FirstValue);
            }
            if (bindingContext.ValueProvider.GetValue("Date2").Count() > 0)
            {
                person.Date2 = Convert.ToDateTime(bindingContext.
                    ValueProvider.GetValue("Date2").FirstValue);
            }
            if (bindingContext.ValueProvider.GetValue("Id").Count() > 0)
            {
                person.Id = Convert.ToInt32(bindingContext.
                    ValueProvider.GetValue("Id").FirstValue);
            }
            if (bindingContext.ValueProvider.GetValue("age").Count() > 0)
            {
                person.age = Convert.ToInt32(bindingContext.
                    ValueProvider.GetValue("age").FirstValue);
            }
            if (bindingContext.ValueProvider.GetValue("dateOfBirth").Count() > 0)
            {
                person.dateOfBirth = Convert.ToDateTime(bindingContext.
                    ValueProvider.GetValue("dateOfBirth").FirstValue);
            }
            if (bindingContext.ValueProvider.GetValue("tags").Count() > 0)
            {
                foreach(var tag in bindingContext.ValueProvider.GetValue("tags"))
                {
                    person.tags.Add(tag);
                }
            }

            bindingContext.Result = ModelBindingResult.Success(person);

            return Task.CompletedTask;
        }
    }
}
