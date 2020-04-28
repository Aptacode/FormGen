  <img width="256" height="256" src="https://github.com/Timmoth/Aptacode.Forms/blob/master/Resources/BannerSquare.png">

Create cross platform forms using C# .net

  <img width="703" height="373" src="https://github.com/Timmoth/Aptacode.Forms/blob/master/Resources/demo.png">


### ToDos

#### Simple changes and documentation

These are relatively simple **potential** additions that will make the library to get started with, and more reliable.

 - Extend this Readme to point to each the various helper-resources.
 - A UML diagram showing the inheritance hierarchy and/or the overarching architecture of various coupled classes. For example, `CheckBoxField` inheriting from `FormField`. `FormField` inherits from `FormElement`, and makes use of the abstract `ValidationRule` (which has it's own architecture).
   - It's currently a bit of a web where it's unclear how to even start using any of it. 
 - A guide that explains how to use the library. Could be as simple as a Readme that explain the `Forms.Wpf.Demo` project.
 - More test cases.
 - Add doc-strings to important classes.

#### Major Changes

These are changes that would require fairly serious changes, but would also add make future development easier.

 - Use dependency injection in `Forms` (*maybe* also in `Forms.Wpf`). This is critical to being able to properly test various components/classes that need mock-dependencies (you want to avoid unit tests that have to connect to the file system, or where running them might affect the underlying system and vice-versa).

### Questions

 - Why does `TextField` have a public empty constructor? `_rules` has no mechanism to be updated later, leading to nullpointer exceptions when using that constructor and either `GetValidationMessages()` or `IsValid()`.
 - Should `TextField._rules` maybe clone the `IEnumerable` (`rules`) being assigned to it? By simply assigning a reference to the original, the rules can be updated at any time - this may be useful when testing, but it could lead to hard-to-track bugs if users create rules at unexpected times (see `TextField_IsValid_SingleValidRuleShouldReturnTrue` for an example of this belated-rule-injection).
 - What's the difference between `ValidationRule` and `ValidationRule<TField>` - they seem like they should be used in similar situations... but they have very different non-constructor methods.
   - For example, when and why do you use one vs the other.
   - Am I right in thinking that `ValidationRule` is only used as a parent class for `ValidationRule<TField>`?
