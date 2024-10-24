Full course [here](https://www.youtube.com/watch?v=-qfEOE4vtxE&ab_channel=freeCodeCamp.org).

# What is Bootstrap?

Bootstrap is the mos popular Fronte-End framework. It is used for building responsive, mobile first websites and web applications.

# Why use Bootstrap?

- Increase development speed.
- Assure responsiveness.
- Prevent repetition between projects.
- Add consistency.
- Ensure cross browser compatibility.
- Large community.
- Customizable.

# Installation

Navigate to [getbootstrap.com](https://getbootstrap.com) and either download, unzip and link it in your index.html (both bootstrap.js and bootstrap.css) or install it via CDN or NPM.

# Grid system

Boostrap uses rows and columns. In each row you have 12 columns to use.

xxl, xl, lg, md, sm and xs are the screen sizes. For example if one element has col-xxl-1 it will ocuppy one out of 12 units in a xxl screen. If the same element has also col-xl-2 it will occupy two out of the 12 units in a xl screen. If the element has col-xs-12 it will ocuppy the whole row (12 columns) of an xs screen.

The class .container has margins. If you don't want that margins you can use the class ".container-fluid" and if you want margins but until a certain breakpoint of size screen you can use, for example, "container-md" which would have margins only for screens bigger than 720px.

If in a column we only use the class "col" bootstrap will automatically calculate the width of each column based on the number of columns. We can specify the width of a column using classes of "col-4", "col-5", etc. Example using screen breakpoints:

In the following code there will be a column of size 8 followed by a column of size 4 for medium and bigger screens and the columns will be displayed on two separate rows for screens smaller than medium.

```html
<div class="col-md-8">Col 1</div>
<div class="col-md-4">Col 2</div>
```

You can also mix screen sizes. For example, in the following code, the first column would have size 8 and the second columns size 4 on a large screen, the first column would have size 6 and the second column would also have size 6 in a medium screen and they would be in two separate rows in a screen smaller than a medium screen.

```html
<div class="col-lg-8 col-md-6">Col 1</div>
<div class="col-lg-4 col-md-6">Col 2</div>
```

You can align items vertically in a row by giving a row the class "align-items-start", "align-items-center" or "align-items-end". For horizontal alignment we have the classes "justify-content-start", "justify-content-center" and "justify-content-end".

The class "my-5" would give an element a vertical margin of 5 (y axis) and the class "mx-5" would give an element a horizontal margin of 5 (x-axis)

**Gutters** are the padding between your columns, used to responsively space and align content in the Bootstrap grid system. For example give a space of 5 between vertical elements:

```html
<div class="container my-5">
    <div class="row gx-1 gy-5">
        <div class="col-6"></div>
        <div class="col-6"></div>
    </div>
</div>
```

# Buttons

Example of [button](https://getbootstrap.com/docs/5.3/components/buttons/) styles:

```html
<button type="button" class="btn btn-primary">
<button type="button" class="btn btn-outline-primary">
```

The first button has a primary color and the second one has the primary color on the border and when hover over the primary color on the button.

We can also adjust the size of a button with the classes "btn-lg" and "btn-sm".

We can also give the disabled style to a button by adding the "disabled" property.

# Cards

[Bootstrap's cards](https://getbootstrap.com/docs/5.3/components/card/) provide a flexible and extensible content container with multiple variants and options. In the following example we can see a card with an image, a card title, some text and a button.

```html
<div class="card" style="width: 18rem;">
  <img src="https://picsum.photos/300/200" class="card-img-top" alt="...">
  <div class="card-body">
    <h5 class="card-title">Card title</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
    <a href="#" class="btn btn-primary">Go somewhere</a>
  </div>
</div>
```

You can place that card inside a div with a class "col-x" that is inside a div with a class "row" if you want to change the card size. Other option is to add the "w-50" (50% width) class to the card to change its size. The third option is to use style="width: 18rem".

We can also create group cards by wrapping several cards with a div that has the class "card-group".

We can also change the card theme by adding for example "text-white bg-dark" so the card has a dark color with a white text.

# Typography

Check also official documentation on [typography](https://getbootstrap.com/docs/5.3/content/typography/).

Bootstrap also has predefined styles.

Headings also are responsive, the text size changes a little on different screen sizes. You can also give a paragraph the class "h1" in case you don't want to use the <h1></h1> tag element.

We also have inline text elements like "<em></em>" for bold text and <mark></mark> for highlighted text.

The following code shows a quote in a classic style:

```html
<figure class="text-center">
  <blockquote class="blockquote">
    <p>A well-known quote, contained in a blockquote element.</p>
  </blockquote>
  <figcaption class="blockquote-footer">
    Someone famous in <cite title="Source Title">Source Title</cite>
  </figcaption>
</figure>
```

# Responsive images

Check also the official documentation on [images](https://getbootstrap.com/docs/5.3/content/images/).

If the image expands more than the available size you can add to the image the class "img-fluid".

The class "img-thumbnail" would give the image a rounded border of 1px.

We can have floating images adding, for example, the class "float-end" to the image. To center the image we could add the class "d-block mx-auto w-25" to the image.

# Utilities

[Spacing](https://getbootstrap.com/docs/5.3/utilities/spacing/):
- "m" stands for margin, so "mt-5" would give the element a margin top of 5.
- "p" stands for padding, so "pt-5" would give the element a padding top of 5.

Sides: t for top, b for bottom, s for start, e for end, x for horizontal, y for vertical and blank for all 4 sides.

Size ranges from 0 to 5 or auto.

You can hide an element in a mobile screen adding the class "d-none d-md-block" which will show that element on screens bigger than medium size and hide it in the smaller ones.

Using [flex](https://getbootstrap.com/docs/5.3/utilities/flex/) you can quickly manage the layout, alignment, and sizing of grid columns, navigation, components, and more with a full suite of responsive flexbox utilities.

# Tables

Check the official documentation for [tables](https://getbootstrap.com/docs/5.3/content/tables/).

Make a table responsive wrapping the table element with a div with the class "table-responsive-md". The table inside that div would be responsive for screens smaller than medium size.

Giving the table element the class "table-dark" changes the theme of the table to a dark one and giving the class "table-bordered" adds borders to the table. If you use the class "table-hover" the hovered row of the table will be hightlighted. The class "table-striped" gives each odd row a different color so it is easier to read.

# Alerts

Check the official documentation for [alerts](https://getbootstrap.com/docs/5.3/components/alerts/).

By creating a div with the class "alert alert-primary" you create a simple alert.

[Toasts](https://getbootstrap.com/docs/5.3/components/toasts/) work like alerts and are also dismissable. You can create a simple toast giving the class "toast-body" to a div.

# Navs and Navbars

Check the official documentation for [navs](https://getbootstrap.com/docs/5.3/components/navs-tabs/) and [navbars](https://getbootstrap.com/docs/5.3/components/navbar/).

The navbar is responsive by default.

Use container if you want to have margins in your navbar and container-fluid if you don't.

You can add the class "fixed-top" to the navbar so it always stays on top of the page when scrolling down.

Nav is used for navigation below the navbar for example. Tabs are for changing the content shown on the page.

# Icons

Check the official documentation for [icons](https://getbootstrap.com/docs/5.3/extend/icons/).

Bootstrap doesn't include an icon set by default but they have their own icon library called Bootstrap icons. To use them simply navigate to [https://icons.getbootstrap.com/](https://icons.getbootstrap.com/), search for your icon, check the previews to know how it will be like in your page and then choose one out of the three options to add it (download, icon font (previously installing the icon library) or html).

# Forms

Check the official documentation for [forms](https://getbootstrap.com/docs/5.3/forms/overview/).

This classes help us making our forms prettier.

Example of a field with a floating label:

```html
<div class="form-floating mb-3">
  <input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">
  <label for="floatingInput">Email address</label>
</div>
```

You can also easily add validation labels.

# Other components

[Accordion](https://getbootstrap.com/docs/5.3/components/accordion/) allows to compact and expand some text.

[Breadcrums](https://getbootstrap.com/docs/5.3/components/breadcrumb/) if you want to show the user where he is.

[Dropdowns](https://getbootstrap.com/docs/5.3/components/dropdowns/) if you want to show more info.

[Modals](https://getbootstrap.com/docs/5.3/components/modal/) if you want to show a popup with some text and action.

[Scrollspy](https://getbootstrap.com/docs/5.3/components/scrollspy/) is for giving the user information on what part of the scrolling page is, it works like a visual hint.

[Spinners](https://getbootstrap.com/docs/5.3/components/spinners/) are used while we are loading something.

[Tooltips](https://getbootstrap.com/docs/5.3/components/tooltips/) are for showing more information when a user hovers on some element.

# Approach

When using a new component search the official documentation and copy the basic use case. Then you can remove or change elements so it suits your needs and also read the documentation if you want to add some styles.

# Landing page project

The project example is places on ./landing/index.html.

Install bootstrap via CDN link and script references.

Search for the navbar and change the theme of the navbar to dark.

Add [jumbotron](https://getbootstrap.com/docs/4.0/components/jumbotron/) which is a lightweight, flexible component for showcasing hero unit style content.

TIP: For writing code with Emmet abbreaviations you start with a dot and press the tab keyboard when the instructions are ready. For example, for faster typing a div with a container class just type ".container" and press the tab keyboard. For adding a paragraph with the class mt-4 you can type p.mt-4 and press the tab keyword.

TIP: For adding Lorem ipsum just type LoremX where X is the length of the text and press the enter keyword.

Add a [Card group](https://getbootstrap.com/docs/5.3/components/card/#card-groups).

Add a [Form](https://getbootstrap.com/docs/5.3/forms/overview/) below the card group.

Search for and add a [Bootstrap footer](https://getbootstrap.com/docs/5.2/examples/footers/).

Publish your page simply by downloading [mdb](https://mdbgo.com/) and typing "mdb publish" on the commandline on the folder where you have your index.html.