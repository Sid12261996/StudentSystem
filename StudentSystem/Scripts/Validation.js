$("#Form-Body").on( 'focus',function validation() {
    var name = $("#Sname").val();
    var pwd = $("#pwd").val();
    var cpwd = $("#cpwd").val();
    console.log("name"+name);
    var err = true;
    $(".Error").show();
     

   
        userValidation();
        passwordValidation();
        confirmpassword();
        if(err){
            $(".Error").show();
           
        }
        $("#Sname").on('focus',()=>{
        
            $("#nameErr").html("");
            $("#pwdErr").html("");

        });

    function userValidation()
            {    
                            if(name.length<=4 || name.length>=20   )
                            {
                                err = false;
                                console.log("name sucess");
                                
                                
                                $("#nameErr").html(" * Username should be between the length of 4 to 20");
                                
                            }
                }
      function passwordValidation()          
                {
                        if(pwd.length<=4 || pwd.length>=20)
                        {
                            err = false;
                            
                           
                            $("#pwdErr").html("* Password should be between the length of 4 to 20");
                            
                        }
    }
    function confirmpassword() {
        if (pwd != cpwd) {
            err = false;


            $("#cpwdErr").html("Password didn't match with the one you entered above");

        }
    }
   
}); 