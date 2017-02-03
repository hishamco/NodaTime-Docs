<!DOCTYPE html>
<!--[if IE 8]> <html class="no-js lt-ie9" lang="en" > <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js" lang="en" > <!--<![endif]-->
<head>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width" />
	<title>{{title}}</title>
	<!-- foundation default -->
  	<link rel="stylesheet" href="/css/foundation.css" />
    <!-- Foundicons -->
    <link rel="stylesheet" href="/css/general_enclosed_foundicons.css">
	<script src="/js/vendor/custom.modernizr.js"></script>
    <link rel="stylesheet" href="/css/main.css">
	<!-- Handlerbars -->
	<script src="/js/handlebars-v4.0.5.js"></script>
	<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');
  ga('create', 'UA-60886284-1', 'auto');
  ga('send', 'pageview');
	</script>
</head>
<body>
	<div class="fixed">
		<nav class="top-bar">
			<ul class="title-area">
				<li class="name"><h1><a href="">Noda Time</a></h1></li>
				<!-- Remove the class "menu-icon" to get rid of menu icon. Take out "Menu" to just have icon alone -->
    			<li class="toggle-topbar menu-icon"><a href="#"><span>Menu</span></a></li>
			</ul>
			<section class="top-bar-section">
				<!-- Right Nav Section -->
			    <ul class="right">
			      <li class="divider"></li>
			      <li class="has-dropdown">
			      	<a href="#" class="active">User Guide</a>
			      	<ul class="dropdown">
			      		<li><label>Versions</label></li>
			      		<li><a href="/1.0.x/userguide">1.0.x</a></li>
			      		<li><a href="/1.1.x/userguide">1.1.x</a></li>
			      		<li><a href="/1.2.x/userguide">1.2.x</a></li>
			      		<li><a href="/1.3.x/userguide">1.3.x</a></li>
			      		<li class="divider hide-for-small"></li>
			      		<li><a href="/unstable/userguide">Unstable</a></li>
			      	</ul>
			      </li>
                  <!-- Disable the API link for the moment...
			      <li class="divider hide-for-small"></li>
			      <li><a href="{{relative}}api" {% if page.navigation == "api" %}class="active"{% endif %}>API</a></li>
                  -->
			      <li class="divider hide-for-small"></li>
			      <li class="has-dropdown">
			      	<a href="#">API</a>
			      	<ul class="dropdown">
			      		<li><label>Versions</label></li>
			      		<li><a href="/1.0.x/api">1.0.x</a></li>
			      		<li><a href="/1.1.x/api">1.1.x</a></li>
			      		<li><a href="/1.2.x/api">1.2.x</a></li>
			      		<li><a href="/1.3.x/api">1.3.x</a></li>
			      		<li class="divider hide-for-small"></li>
			      		<li><a href="/unstable/api">Unstable</a></li>
			      	</ul>
			      </li>
			      <li class="divider"></li>
			      <li>
                       <a href="/developer">Developer Guide</a>
			      </li>
			      <li class="divider"></li>
			      <li><a href="/#info">More Info</a></li>
			      <li class="divider show-for-small"></li>
			      <li class="has-form hide-for-small">
			        <a class="button" href="/#install">Install</a>
			      </li>
			    </ul>
			</section>
		</nav>
	</div>
	<section class="body">
<div class="row">
	<div class="large-9 columns">
		<h1>{{title}}</h1>
		{{body}}
		<ul class="pagination">
			<li class="current hide-for-small"><a href>{{ title }}</a></li>
			{{#if nextPage.url '!=' '#'}}
				<li><a href="{{ nextPage.url }}"><strong>Next</strong>: {{ nextPage.title }}</a></li>
			{{/if}}
		</ul>
	</div>
	<div class="large-3 columns">
		<div class="section-container accordian">
			{{#each categories}}
				<section>
					<p class="title" data-section-title>{{name}}</p>
					<div class="content" data-section-content>
						<ul class="side-nav">
							{{#each pages}}
								{{#if title '==' 'Noda Time User Guide'}}
									<li><a href="{{url}}" class="active">Overview</a></li>
								{{else}}
									<li><a href="{{url}}" class="active">{{title}}</a></li>
								{{/if}}
							{{/each}}
						</ul>
					</div>
				</section>
			{{/each}}
			<footer>Version {{version}}</footer>
		</div>
	</div>
</div>
	</section>
	<footer>
		<div class="row">
			<div class="small-6 columns">
                                <span>The latest version is {{site.latest}}, released {{site.latest_released_on}}</span>
			</div>
			<div class="small-6 columns copy">
                                &copy; <a href="https://github.com/nodatime/nodatime/blob/master/AUTHORS.txt">The Noda Time Authors</a>,
                                <span class="design">Web Design by <a href="http://nathanpalmer.com">Nathan Palmer</a></span>
			</div>
		</div>
	</footer>
		<script>
	<script src="/js/vendor/zepto.js"></script>
	<script src="/js/jquery-2.1.1.min.js"></script>
	<script src="/js/foundation.min.js"></script>
  <script>
    $(document).foundation();
  </script>
  <script type="text/javascript">
		$(function(){
			var context = {};
			$.get("/config.json", function(result)
			{
				context = eval(result);
				context.title = "";
				context.prevPage = {};
				context.nextPage = {};
				var pages = getPages(context.categories);
				setTitle(pages);
				// evaluate the tokens in the 'title' tag
				var source = $("title").text();
				var template = Handlebars.compile(source);
				var html = template({
					"siteName": context.siteName,
					"title" : context.title
				});
				$("title").text(html);
				// evaluate the tokens in the 'body' tag
				source = $("body").html();
				Handlebars.registerHelper('if', ifHelper);
				template = Handlebars.compile(source);
				html = template(context);
				$("body").html(html);
			});
			function getPages(categories){
				var pages = [];
				$.each(categories, function(index, item){
					$.each(item.pages, function(index, item){
						pages.push(item);
					});
				});
				return pages;
			}
			function setTitle(pages)
			{
				var url = location.href;
				var slashIndex = url.lastIndexOf("/");
				var pageUrl = url.substring(slashIndex + 1);
				if(pageUrl == "")
				{
					context.title = pages[0].title;
					context.prevPage.title = "";
					context.prevPage.url = "#";
					context.nextPage.title = pages[1].title;
					context.nextPage.url = pages[1].url;
					return;
				}
				for(var i = 1; i < pages.length; i++)
				{			
					if(pages[i].url == pageUrl){
						context.title = pages[i].title;
						context.prevPage.title = pages[i-1].title;
						context.prevPage.url = pages[i-1].url;
						if(pages.length - 1 == i){
							context.nextPage.title = "";
							context.nextPage.url = "#";
						}
						else{
							context.nextPage.title = pages[i+1].title;		
							context.nextPage.url = pages[i+1].url;
						}
						break;
					}
				}
			}
			function ifHelper (v1, operator, v2, options) {
				switch (operator) {
					case '==':
						return (v1 == v2) ? options.fn(this) : options.inverse(this);
					case '===':
						return (v1 === v2) ? options.fn(this) : options.inverse(this);
					case '!=':
						return (v1 != v2) ? options.fn(this) : options.inverse(this);
					case '!==':
						return (v1 !== v2) ? options.fn(this) : options.inverse(this);
					case '<':
						return (v1 < v2) ? options.fn(this) : options.inverse(this);
					case '<=':
						return (v1 <= v2) ? options.fn(this) : options.inverse(this);
					case '>':
						return (v1 > v2) ? options.fn(this) : options.inverse(this);
					case '>=':
						return (v1 >= v2) ? options.fn(this) : options.inverse(this);
					case '&&':
						return (v1 && v2) ? options.fn(this) : options.inverse(this);
					case '||':
						return (v1 || v2) ? options.fn(this) : options.inverse(this);
					default:
						return options.inverse(this);
				}
			}
		});
	</script>
  <!-- Nuget Button -->
  <script type="text/javascript">
  (function () {
      var nb = document.createElement('script'); nb.type = 'text/javascript'; nb.async = true;
      nb.src = 'http://s.prabir.me/nuget-button/0.2.1/nuget-button.min.js';
      var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(nb, s);
  })();
  </script>
</body>
</html>