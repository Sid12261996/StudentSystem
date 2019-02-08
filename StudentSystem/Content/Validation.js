document.on('ready', function validation() {
    var name = $("#Sname").val();
    var pwd = $("#pwd").val();
    var button = $("#but-submit");
    var err = true;
    $(".Error").show();
     
 
    
    {
        userValidation();
        passwordValidation();
        if(err){
            $(".Error").show();
           
        }
        $("#name").on('focus',()=>{
        
            $("#nameErr").html("");
            $("#pwdErr").html("");

        });
    }
    function userValidation()
            {    
                            if(name.length<=4 || name.length>=20 ||  )
                            {
                                err = false;
                                console.log("name sucess");
                                
                                
                                $("#nameErr").html(" *Invalid Username ");
                                
                            }
                }
      function passwordValidation()          
                {
                        if(pwd.length<=4 || pwd.length>=20)
                        {
                            err = false;
                            
                           
                            $("#pwdErr").html("*Invalid password ");
                            
                        }
                }    
    
   
}); 