﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace WebAPI.Tests.Acceptance.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class StudentManagementFeature : object, Xunit.IClassFixture<StudentManagementFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "StudentManagement.feature"
#line hidden
        
        public StudentManagementFeature(StudentManagementFeature.FixtureData fixtureData, WebAPI_Tests_Acceptance_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "StudentManagement", "Create, Read, Update, Delete Student", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="User creates, reads, updates and deletes a student")]
        [Xunit.TraitAttribute("FeatureTitle", "StudentManagement")]
        [Xunit.TraitAttribute("Description", "User creates, reads, updates and deletes a student")]
        public void UserCreatesReadsUpdatesAndDeletesAStudent()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User creates, reads, updates and deletes a student", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 9
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 10
 testRunner.Given("platform has \"0\" students", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "BirthDate",
                            "GitHubUsername"});
                table1.AddRow(new string[] {
                            "John",
                            "Doe",
                            "john@doe.com",
                            "2004-01-01",
                            "john-doe"});
#line 11
 testRunner.When("user creates a student with following data by sending \'Create Student Command\' th" +
                        "rough API", ((string)(null)), table1, "When ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "BirthDate",
                            "GitHubUsername"});
                table2.AddRow(new string[] {
                            "John",
                            "Doe",
                            "john@doe.com",
                            "2004-01-01",
                            "john-doe"});
#line 14
 testRunner.Then("user requests to get all the students and it must return \"1\" student with followi" +
                        "ng data", ((string)(null)), table2, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "BirthDate",
                            "GitHubUsername"});
                table3.AddRow(new string[] {
                            "John",
                            "Doe",
                            "john@gmail.com",
                            "2004-01-01",
                            "john-doe"});
#line 17
 testRunner.When("user creates another student with following data by sending \'Create Student Comma" +
                        "nd\' through API", ((string)(null)), table3, "When ");
#line hidden
#line 20
 testRunner.Then("user must get status code \"500\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "BirthDate",
                            "GitHubUsername"});
                table4.AddRow(new string[] {
                            "Jane",
                            "William",
                            "jane@william.com",
                            "2000-01-01",
                            "jane-will"});
#line 21
 testRunner.When("user updates student by email \"john@doe.com\" with following data", ((string)(null)), table4, "When ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "BirthDate",
                            "GitHubUsername"});
                table5.AddRow(new string[] {
                            "Jane",
                            "William",
                            "jane@william.com",
                            "2000-01-01",
                            "jane-will"});
#line 24
 testRunner.Then("user requests to get all the students and it must return \"1\" student", ((string)(null)), table5, "Then ");
#line hidden
#line 27
 testRunner.When("user deletes student by Email of \"jane@william.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 28
 testRunner.Then("user requests to get all students and it must return \"0\" students", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                StudentManagementFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                StudentManagementFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion