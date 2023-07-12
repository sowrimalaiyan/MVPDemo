export const environment = {
  "mainAPI":{
    production: false,
    title: 'Local Environment Heading',
    apiURL: 'http://localhost:5170/'
  },
  "skillURL":{
    create:'api/Skills/insert',
    update:'api/Skills/update',
    delete:'api/Skills/delete',
    get:'api/Skills/get'
  },
  "jobURL":{
    create:'api/JobSkills/insert',
    update:'api/JobSkills/update',    
    delete:'api/JobSkills/delete',
    get:'api/JobSkills',
    getAllJob: 'api/Job/get'
  },
  "employeeURL":{
    create:'api/EmployeeSkills/insert',
    update:'api/EmployeeSkills/update',
    delete:'api/EmployeeSkills/delete',
    get:'api/EmployeeSkills',
    getAllEmployee :'api/Employee/get'
  }
    
  };
  