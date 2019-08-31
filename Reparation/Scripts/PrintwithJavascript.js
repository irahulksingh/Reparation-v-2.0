window.print_this = function(id) {
    var prtContent = document.getElementById(id);
    var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=900,toolbar=0,scrollbars=0,status=0');
    
    WinPrint.document.write('<link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">');

    //var file = WinPrint.document.createElement("link");
    //file.setAttribute("rel", "stylesheet");
    //file.setAttribute("type", "text/css");
    //file.setAttribute("href", 'https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css');

    //WinPrint.document.head.appendChild(file);

    
    WinPrint.document.write(prtContent.innerHTML);
    WinPrint.document.close();
    WinPrint.setTimeout(function(){
      WinPrint.focus();
      WinPrint.print();
      WinPrint.close();
    }, 1000);
}