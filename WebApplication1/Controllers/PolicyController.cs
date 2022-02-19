using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Mappers;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class PolicyController : Controller
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IPolicyMapper _policyMapper;

        public PolicyController(IPolicyRepository policyRepository, IPolicyMapper policyMapper)
        {
            _policyRepository = policyRepository;
            _policyMapper = policyMapper;
        }

        [HttpPost]
        public ActionResult<Policy> Create([FromBody] Policy policy)
        {
            _policyRepository.Add(policy);
            return Ok();
        }

        [HttpGet("{policyId}")]
        public ActionResult<Policy> Read(int policyId)
        {
            var policy = _policyRepository.Get().FirstOrDefault(x => x.PolicyNumber == policyId);
            if (policy == null)
            {
                return NotFound("Policy not found");
            }
            return Ok(policy);
        }

        [HttpPut("{policyId}")]
        public ActionResult<Policy> Update([FromBody] Policy policy, int policyId)
        {
            var existingPolicy = _policyRepository.Get().FirstOrDefault(x => x.PolicyNumber == policyId);
            if (existingPolicy == null)
            {
                return NotFound("Policy not found");
            }
            _policyMapper.MapPolicy(policy, existingPolicy);
            return existingPolicy;
        }

        [HttpDelete("{policyId}")]
        public ActionResult Delete(int policyId)
        {
            _policyRepository.Remove(policyId);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Policy>> GetAll()
        {
            return Ok(_policyRepository.Get());
        }
    }
}
