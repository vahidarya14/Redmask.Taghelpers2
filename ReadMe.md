# Redmask.Taghelpers 

## Description
Some useful UI taghelpers  
 tinymc5 + roxyfilenam , persian calendar picker , image chooser dialog(instead of file input) , social share btn

source code and sample : https://github.com/vahidarya14/Redmask.Taghelpers2

#### sample usage source:

add this in head of site
```csharp
     @Html.RedmaskCss(new CssPool(Bootstrap.v5).PersianDateTimePicker().Kendo2020().AdminLTE3().TagInput().PersianCss())
   <script src="~/_content/Redmask.Taghelpers/lib/jquery/jquery.min.js"></script>
```
and this in footer (or header)
```csharp
    @Html.RedmaskJs(new ScriptsPool(Bootstrap.v5).PersianDateTimePicker().Kendo2020().AdminLTE3().TinyMCE5().TagInput())

```
 add ```csharp @addTagHelper *,Redmask.Taghelpers ``` to **_ViewImport.cshtml**

Done

>[!NOTE]
>_you can ignore **PersianDateTimePicker** or **Kendo2020** or **AdminLTE** or **TagInput** or **PersianCss** if you aren't using these component.and just add needed css and js_
> 
# usage

#### imageChooser:
```html
  <imageChooserFor asp-for="Icon" folder-path="@Setting.ContentsFolder" max-kb="1500" img-css="max-height:200px;border:2px solid blue;" ></imageChooserFor>
```
![](res/imageChooserFor.jpg)

#### TagInput:
```html
   <TagInputFor asp-for="Tags" seperator=","/>
```
![](res/TagInputFor.jpg)

#### PersianDatePicker:
if you are using bootstrap 5
```html
    <PersianDatePickerBs5For asp-for="CreateDate" />
```
if you are using bootstrap 4
```html
    <PersianDatePickerBs4For asp-for="CreateDate" />
```
![](res/PersianDatePickerFor.jpg)

#### TinyMce5
```html
  <TinyMce5For asp-for="Description" language="fa_IR" directionality="rtl">some content</TinyMce5For>

```
![](res/TinyMce5For.jpg)

#### Switch
```html
<SwitchFor asp-for="IsActive" label="Is Active" />
```
![](res/SwitchFor.jpg)

#### FloatingLabelInputGroup
```html
<FloatingLabelInputGroup label="نام">
    <input class="form-control" asp-for="Name" placeholder="نام" type="text" />
</FloatingLabelInputGroup>
```

#### none binding tagheplers
```html
<FilterPanel>
    <DropDownFilterItem title="name" id="nameFilter" />
    <CustomeBobyFilter id="familyFilter" title="family">
        <ol class="list-group list-group-numbered px-0">
            <li class="list-group-item d-flex justify-content-between align-items-start">
                <div class="form-check">
                    <input class="filterInput familyFilter" type="checkbox" data-lbl="chk_1" id="flexCheckDefault">
                    <label class="form-check-label" for="flexCheckDefault">
                        Default checkbox
                    </label>
                </div>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-start">
                <div class="form-check">
                    <input class="filterInput familyFilter" type="checkbox" data-lbl="chk__2" id="flexCheckChecked">
                    <label class="form-check-label" for="flexCheckChecked">
                        Checked checkbox
                    </label>
                </div>
            </li>
        </ol>
    </CustomeBobyFilter>
    <FilterItem>
        <FilterBadge>
            تاریخ:
            <span class="badge badge-warning" id="dateFromFilter2-has"></span>
            <span class="badge badge-warning" id="dateToFilter2-has"></span>
            <i class="las la-angle-down"></i>
        </FilterBadge>
        <FilterBody>
            <div class="p-2 pt-4">
                <PersianDatePicker class="filterInput" id="dateFromFilter" />
                <PersianDatePicker class="filterInput" id="dateToFilter" />
            </div>
        </FilterBody>
    </FilterItem>
</FilterPanel>
```
![](res/filterPanel.jpg)

```html
<imageChooser name="aa"  ></imageChooser>
<PersianDatePickerBs5 id="picker1" ></PersianDatePickerBs5>
<ShareBtnBs5 use-current-url="true" class="float-left btn-success" />
<ShareBtnBs4 use-current-url="true" class="float-left btn-danger" />
```
