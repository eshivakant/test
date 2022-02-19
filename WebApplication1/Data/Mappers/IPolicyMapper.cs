using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Mappers
{
    public interface IPolicyMapper
    {
        void MapPolicy(Policy source, Policy target);
        void MapPolicyHolder(PolicyHolder source, PolicyHolder target);
    }
    public class PolicyMapper : IPolicyMapper
    {
        public void MapPolicy(Policy source, Policy target)
        {
            target.PolicyNumber = source.PolicyNumber;
            MapPolicyHolder(source.PolicyHolder, target.PolicyHolder);
        }

        public void MapPolicyHolder(PolicyHolder source, PolicyHolder target)
        {
            target.Age = source.Age;
            target.Gender = source.Gender;
            target.Name = source.Name;
        }      
    }
}
