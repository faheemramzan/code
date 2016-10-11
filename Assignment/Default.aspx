<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Assignment.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment</title>    
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="CSS/bootstrap.min.css"/>        
        
    <script src="Scripts/External/angular.min.js"></script>

    <script src="Scripts/External/jquery.min.js"></script>
    <script src="Scripts/External/bootstrap.min.js"></script>
    <style>
        a {
            cursor: pointer;
        }

        select{
            padding: 4px;
        }

        dd {            
            margin-bottom: 10px;
        }

        .tab-content{
            margin: 10px;
        }
    </style>
</head>
<body>
    <form id="mainForm" runat="server">        
        <div ng-app="myApp">
            <div>
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="pill" href="#tab-persons">Person</a></li>
                    <li><a data-toggle="pill" href="#tab-companies">Företag</a></li>
                </ul>
                <div class="tab-content">
                    <div id="tab-persons" class="tab-pane fade active in">                       
                        <div ng-controller="personsController">
                            <div>
                                <label>Företag:</label> <select id="dropdownCompanies"
                                                 ng-model="selectedCompany" 
                                                 ng-init="selectedCompany = noCustomerFilter" 
                                                 ng-options="company.Name for company in companies"
                                                 ng-change="setSelectedCompanyFilter(selectedCompany)">

                                         </select>
                            </div>
                            <div>
                                <table class="table table-striped">
                                    <thead>
                                        <tr>                                               
                                            <th>Namn</th>
                                            <th>Företag</th>                    
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr ng-repeat="person in persons | filter:personsFilter(selectedCompanyFilter)">                                             
                                            <td>{{person.Name}}</td> 
                                            <td>{{getCompanyName(person.CompanyKey)}}</td>                    
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <a data-toggle="modal" data-target="#addPersonDialog">Skapa person</a>                           
                            <div id="addPersonDialog" class="modal fade" role="dialog">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                                          <h3 class="modal-title">Skapa person</h3>
                                        </div>
                                        <div class="modal-body">
                                            <dl>                        
                                                <dt>Namn</dt>
                                                <dd><input type="text" ng-model="newPerson.Name" /></dd>
                                                <dt>Företag</dt>
                                                <dd>
                                                    <select ng-model="newPersonCompany" ng-init="newPersonCompany = noCustomerFilter" 
                                                             ng-options="company.Name for company in companies">

                                                    </select>
                                                </dd>
                                            </dl>                                           
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" ng-click="add()" data-dismiss="modal">Skapa</button>
                                        </div>
                                    </div>
                                </div>
                            </div>                             
                        </div>
                    </div>
                    
                    <div id="tab-companies" class="tab-pane fade">                        
                        <div ng-controller="companiesController">
                            <div>
                                <table class="table table-striped">
                                    <thead>
                                        <tr>                                                
                                            <th>Namn</th> 
                                            <th></th>                   
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr ng-repeat="company in companies">                                            
                                            <td>{{company.Name}}</td>   
                                            <td><a ng-click="showPersons(company)">Anställda</a></td>                 
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div>
                                <a data-toggle="modal" data-target="#addCompanyDialog">Skapa företag</a>
                            </div>                            
                            <div id="addCompanyDialog" class="modal fade" role="dialog">
                                <div class="modal-dialog span-24">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                                          <h3 class="modal-title">Skapa företag</h3>
                                        </div>
                                        <div class="modal-body">
                                            <dl>                        
                                                <dt>Namn</dt>
                                                <dd><input type="text" ng-model="newCompany.Name" /></dd>                                    
                                            </dl>                                            
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" ng-click="add()" data-dismiss="modal">Skapa</button>
                                        </div>
                                    </div>
                                </div>
                            </div>                            
                        </div>
                    </div>
                </div>
            </div>            
        </div>

        <script src="Scripts/Shared/init.js"></script>
        
        <script src="Scripts/Services/personService.js"></script>
        <script src="Scripts/Services/companyService.js"></script>

        <script src="Scripts/Shared/sharedService.js"></script>

        <script src="Scripts/Controllers/personsController.js"></script>
        <script src="Scripts/Controllers/companiesController.js"></script>

    </form>
</body>
</html>
