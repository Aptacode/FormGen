  <img width="256" height="256" src="https://github.com/Timmoth/Aptacode.Forms/blob/master/Resources/BannerSquare.png">

Create cross platform forms using C# .net

  <img width="572" height="360" src="https://github.com/Timmoth/Aptacode.Forms/blob/master/Resources/demo.png">


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

 - What's the difference between `ValidationRule` and `ValidationRule<TField>` - they seem like they should be used in similar situations... but they have very different non-constructor methods.
   - For example, when and why do you use one vs the other.
   - Am I right in thinking that `ValidationRule` is only used as a parent class for `ValidationRule<TField>`?
