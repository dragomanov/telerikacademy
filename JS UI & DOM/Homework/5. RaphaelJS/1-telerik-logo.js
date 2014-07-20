var paper = Raphael(10, 10, 500, 500);
    logo = paper.path("M 25 35 L 40 20 L 80 60 L 60 80 L 40 60 L 80 20 L 95 35")
           .attr({ stroke: 'lightgreen', 'stroke-width': 10}),
    telerikText = paper.text(105, 58, "Telerik")
                  .attr({ 'text-anchor': 'start', 'font-size': 80, 'font-weight': 'bold', fill: '#333' }),
    rtm = paper.text(370, 50, "®")
          .attr({ 'font-size': 18, 'font-weight': 'bold', fill: '#333'});
    slogan = paper.text(121, 110, "Develop experiences")
             .attr({ 'text-anchor': 'start', 'font-size': 36,  fill: '#666' });
