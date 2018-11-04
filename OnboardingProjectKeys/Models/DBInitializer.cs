using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnboardingProjectKeys.Models
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<KeysOnboardingContext>
    {

        protected override void Seed(KeysOnboardingContext context)
        {
            base.Seed(context);
        }
    }
}