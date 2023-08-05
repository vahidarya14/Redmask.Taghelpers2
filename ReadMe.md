# Redmask.Taghelpers 

## Description
Some useful UI taghelpers  
source code and sample : https://github.com/vahidarya14/Redmask.Taghelpers2

#### sample usage source:

add this in head of site
```
    @Html.RedmaskCss(new CssPool().Bootstrap4().PersianDateTimePicker().Kendo2020().AdminLTE().TagInput().PersianCss())
   <script src="~/_content/Redmask.Taghelpers/lib/jquery/jquery.min.js"></script>
```
and this in footer (or header)
```
    @Html.RedmaskJs(new ScriptsPool().Bootstrap4().PersianDateTimePicker().Kendo2020().AdminLTE().TinyMCE5().TagInput())

```
 add ``` @addTagHelper *,Redmask.Taghelpers ``` to _ViewImport.cshtml

Done

# usage

#### imageChooser:
```
  <imageChooserFor asp-for="Icon" folder-path="@Setting.ContentsFolder" max-kb="1500" img-css="max-height:200px;border:2px solid blue;" ></imageChooserFor>
```
![](res/imageChooserFor.jpg)

#### TagInput:
```
   <TagInputFor asp-for="Tags"></TagInputFor>
```
![](res/TagInputFor.jpg)

#### PersianDatePicker:
```
    <PersianDatePickerFor asp-for="CreateDate"></PersianDatePickerFor>
```
![](res/PersianDatePickerFor.jpg)

#### TinyMce5
```
  <TinyMce5For asp-for="Description" language="fa_IR" directionality="rtl">some content</TinyMce5For>

```
![](res/TinyMce5For.jpg)

#### Switch
```
<SwitchFor asp-for="IsActive" label="Is Active"></SwitchFor>
```
![](res/SwitchFor.jpg)

#### none binding tagheplers
```
<imageChooser name="aa"  ></imageChooser>
<PersianDatePicker id="picker1" ></PersianDatePicker>
<ShareBtn ></ShareBtn>
```