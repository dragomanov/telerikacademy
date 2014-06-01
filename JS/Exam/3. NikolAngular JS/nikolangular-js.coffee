Solve = (args) ->
  modelsCount = Number(args[0])
  #console.log("modelsCount =", modelsCount)

  models = {}
  for i in [1..modelsCount]
    key = args[i].split("-")[0]
    value = args[i].split("-")[1].split(";")
    models[key] = value
  #console.log("models =", models)

  viewCount = args[modelsCount+1]
  #console.log("viewCount =", viewCount)

  view = []
  for i in [0...viewCount]
    view[i] = args[modelsCount+i+2]
  #console.log("view =", view)

  templates = []
  inTemplate = no
  html = []
  for line in view
    if line.indexOf('</nk-template>') isnt -1
      inTemplate = no
    if inTemplate
      templates[templateName].push(line)
    if line.indexOf('<nk-template name=') isnt -1
      inTemplate = yes
      templateName = line.substring(line.indexOf('"')+1, line.lastIndexOf('"'))
      templates[templateName] = []
    if line.indexOf('<nk-template name=') is -1 and
        line.indexOf('</nk-template>') is -1 and
        !inTemplate
      html.push(line)
  #console.log("templates =", templates)
  #console.log("html =", html)

  for line, i in html
    newLine = line
    while newLine.indexOf('<nk-model>', newLine.indexOf('}}')) isnt -1 or
          newLine.substring(0, newLine.indexOf('{{')).indexOf('<nk-model>') isnt -1
      key = newLine.substring(newLine.indexOf('<nk-model>')+10, newLine.indexOf('</nk-model>'))
      newLine = newLine.replace("<nk-model>#{key}</nk-model>", models[key])
      #console.log("key =", key)
    html[i] = newLine
  #console.log(html)

  templateHtml = []
  for line in html
    if line.indexOf('<nk-template render=') isnt -1
      templateName = line.substring(line.indexOf('"')+1, line.lastIndexOf('"'))
      for templateLine in templates[templateName]
        templateHtml.push(templateLine)
    else
      templateHtml.push(line)
  #console.log(templateHtml)

  inIf = no
  ifHtml = []
  for line in templateHtml
    if line.indexOf('</nk-if>') isnt -1
      inIf = no
    if line.indexOf('<nk-if') isnt -1
      ifName = line.substring(line.indexOf('"')+1, line.lastIndexOf('"'))
      if not JSON.parse(models[ifName]) then inIf = yes
    if line.indexOf('<nk-if') is -1 and
        line.indexOf('</nk-if>') is -1 and
        !inIf
      ifHtml.push(line)
  #console.log("ifHtml =", ifHtml)

  for line, i in ifHtml
    newLine = line
    while newLine.indexOf('{{') isnt -1
      content = newLine.substring(newLine.indexOf('{{')+2, newLine.indexOf('}}'))
      newLine = newLine.replace("{{#{content}}}", content)
    ifHtml[i] = newLine
  #console.log(ifHtml)

  for line in ifHtml
    console.log(line)
  return

test1 = [
  '6',
  'title-Telerik Academy',
  'showSubtitle-true',
  'subTitle-Free training',
  'showMarks-false',
  'marks-3;4;5;6',
  'students-Ivan;Gosho;Pesho',
  '42',
  '<nk-template name="menu">',
  '    <ul id="menu">',
  '        <li>Home</li>',
  '        <li>About us</li>',
  '    </ul>',
  '</nk-template>',
  '<nk-template name="footer">',
  '    <footer>',
  '        Copyright Telerik Academy 2014',
  '    </footer>',
  '</nk-template>',
  '<!DOCTYPE html>',
  '<html>',
  '<head>',
  '    <title>Telerik Academy</title>',
  '</head>',
  '<body>',
  '    <nk-template render="menu" />',
  '',
  '    <h1><nk-model>title</nk-model></h1>',
  '    <nk-if condition="showSubtitle">',
  '        <h2><nk-model>subTitle</nk-model></h2>',
  '        <div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
  '    </nk-if>',
  '',
  '    <ul>',
  '        <nk-repeat for="student in students">',
  '            <li>',
  '                <nk-model>student</nk-model>',
  '            </li>',
  '            <li>Multiline <nk-model>title</nk-model></li>',
  '        </nk-repeat>',
  '    </ul>',
  '    <nk-if condition="showMarks">',
  '        <div>',
  '            <nk-model>marks</nk-model> ',
  '        </div>',
  '    </nk-if>',
  '',
  '    <nk-template render="footer" />',
  '</body>',
  '</html>'
]

Solve test1


# input =
# calculations =
# output =
