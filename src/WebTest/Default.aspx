﻿<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" 
                    "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
  <script src="http://code.jquery.com/jquery-latest.js"></script>
  <link rel="stylesheet" href="http://code.jquery.com/qunit/git/qunit.css" type="text/css" media="screen" />
<script type="text/javascript" src="http://code.jquery.com/qunit/git/qunit.js"></script>

  <script>
  $(document).ready(function(){
    
test("a basic test example", function() {
  ok( true, "this test is fine" );
  var value = "hello";
  equals( "hello", value, "We expect value to be hello" );
});

module("Module A");

test("first test within module", function() {
  ok( true, "all pass" );
});

test("second test within module", function() {
  ok( true, "all pass" );
});

module("Module B");

test("some other test", function() {
  expect(2);
  equals( true, false, "failing test" );
  equals( true, true, "passing test" );
});

  });
  </script>
  
</head>
<body>
  <h1 id="qunit-header">QUnit example</h1>
 <h2 id="qunit-banner"></h2>
 <div id="qunit-testrunner-toolbar"></div>
 <h2 id="qunit-userAgent"></h2>
 <ol id="qunit-tests"></ol>
 <div id="qunit-fixture">test markup, will be hidden</div>
</body>
</html>