// JScript File

function InvalidDate(txtCtl, strDefValue) 
{ 
    
   var RegExp=/^(0?[1-9]|10|11|12)[/](0?[1-9]|[12][0-9]|30|31)[/](\d{4})$/ 
   strSource=trim(txtCtl.value); 
    
   if(!strSource.length) 
   { 
       if(strDefValue=="0")txtCtl.value="01/01/1900"; 
       else if(strDefValue=="1") txtCtl.value="";//use server date(today) 
       else txtCtl.value=strDefValue; 
       return false; 
   } 
   var Parts=strSource.match(RegExp); 
   if(!Parts) return true; 
   else 
   { 
       var Month=parseInt(Parts[1]),Day=parseInt(Parts[2]),Year=parseInt(Parts[3]); 
       var bInvalid=((Month==4||Month==6||Month==9||Month==11)&&Day==31)||(Month==2 && (Day>29 ||(Day==29 && !Year%4 && Year%100))) 
       if(!bInvalid)if(Year<1753)txtCtl.value="01/01/1753" 
       return bInvalid 
   } 
} 

function checkdateformat(userinput){
var dateformat = /^\d{1,2}(\-|\/|\.)\d{1,2}\1\d{4}$/
return dateformat.test(userinput) //returns true or false depending on userinput
}

function Validate2Dates(FromDt,ToDt)
{
                  
            var FromDate=document.getElementById(FromDt).value;
		    var ToDate=document.getElementById(ToDt).value;   
	    
            if(FromDate=="" || ToDate=="")
            {
                    alert("Please Enter Proper Dates in DD/MM/YYYY Format");
                    document.getElementById(FromDt).focus();
                    return false;
            }	
            
            ans=checkdateformat(FromDate);
		    ans1=checkdateformat(ToDate);
		    if(ans==false || ans1 == false)
		    {
		        alert("Please Enter Valid Date Format DD/MM/YYYY Format");
		        document.getElementById(FromDt).focus();
		        return false;
		    }            
	
		  	var dt1 = FromDate.split("/");
		  	var dt2=  ToDate.split("/");
		  	
			mm1 = (dt1[1]);
			dd1 = (dt1[0]);
			yy1 = (dt1[2]);
			
			cm1 = (dt2[1]);
			cd1 = (dt2[0]);
			cy1 = (dt2[2]);								
			
			FromDate=new Date(yy1,mm1-1,dd1);
			ToDate=new Date(cy1,cm1-1,cd1);
			
            //Set the two dates
            var millennium =new Date(2000, 0, 1) //Month is 0-11 in JavaScript
            today=new Date()
            //Get 1 day in milliseconds
            var one_day=1000*60*60*24

//            alert((ToDate-FromDate)/(one_day));			
			
			if((ToDate-FromDate)/(one_day)>31)
			{
			    alert("Date Difference Can not be More Than 31 Days !!!");
			    return false;			
			}			
			
			if(FromDate>ToDate)
			{
				alert("From Date Should Be Less Than To Date");
				return false;
			}	
return true;
}


function DependentDropDownlist(ddlparent,ddlchild,tablename1,tablename2,col1,col2,col3)
{
			var request;
			var response;
			var dropdownvalues='';
             
                var ddllength = document.all(ddlchild).length;
                    for(i=0;i<ddllength;i++)
                    {                    
						document.all(ddlchild).remove(0);
                    }   			            
             
			var city = document.getElementById(ddlchild);
//			var status = document.getElementById("lblStatus");
            populatecity();

			function populatecity()
			{
				var country = document.getElementById(ddlparent).value;

				if(document.getElementById(ddlparent).value!= '')
				//Check if the selectedItem as not "--Select--"
				{
					return SendRequest(document.getElementById(ddlparent).value);
				}
				else
				{
//					clearSelect(Territory);//Clear the Territory dropdown
					status.innerText = "";//Blank the status text label
				}
			}
			function InitializeRequest()
			{
				try
				{
					request = new ActiveXObject("Microsoft.XMLHTTP");//Try creating an XMLHTTP Object
				}
				catch(Ex)
				{
					try
					{
						request = new ActiveXObject("Microsoft.XMLHTTP");//First failure, try again creating an XMLHTTP Object
					}
					catch(Ex)
					{
						request = null;//Else assign null to request
					}
				}

				if(!request&&typeof XMLHttpRequest != 'undefined')
				{
					request = new XMLHttpRequest();
				}
			}

			function SendRequest(ID)
			{
//				status.innerText = "Loading.....";//Set the status to "Loading....."
				InitializeRequest();//Call InitializeRequest to set request object
//				var url = "cityajax.aspx?country="+ID+"&tablename1="+ID;//Create the url to send the request to
				var url = "Fillddlist.aspx?country="+ID+"&tablename1="+tablename1+"&tablename2="+tablename2+"&col1="+col1+"&col2="+col2+"&col3="+col3;//Create the url to send the request to
				request.onreadystatechange = ProcessRequest;//Delegate ProcessRequest to onreadystatechange property so it gets called for every change in readyState value
				request.open("GET", url, true);//Open a GET request to the URL
				request.send(null);//Send the request with a null body.
			}

			function ProcessRequest()
			{
				if(request.readyState == 4)//If the readyState is in the "Ready" state
				{
					if(request.status == 200)//If the returned status code was 200. Everything was OK.
					{
						if(request.responseText != "")//If responseText is not blank
						{						    
							ans=populateList(request.responseText);//Call the populateList fucntion
//                            alert(ans);
                            return false;
							status.innerText = "Territories Loaded";//Set the status to "Territories Loaded"
						}
						else
						{
							status.innerText = "None Found";//Set the status to "None Found"
//							clearSelect(Territory);//Call clearSelect function
						}
					}
				}
				return true;//return
			}

			function populateList(response)
			{
				var xmlDoc=new ActiveXObject("Microsoft.XMLDOM");//Create the XMLDOM object
				xmlDoc.async = false;
				xmlDoc.loadXML(response);//Load the responseText into the XMLDOM document

				var opt;
				var parentElem = xmlDoc.getElementsByTagName("citymaster");//Create the EmployeeTerritories element
//				var cityElem = parentElem[0].getElementsByTagName("city");//Create the TERRITORIES element
				var cityElem = parentElem[0].getElementsByTagName("_x0023_temp");//Create the TERRITORIES element

//Commented by MJ clearSelect(Territory);//Clear the dropdown before filling it with new values
				if(parentElem.length > 0)//If there are one or more TERRITORIES nodes
				{
				for (var i = 0; i < cityElem.length; i++)//Loop through the XML TERRITORIES nodes
				{
					var textNode = document.createTextNode(cityElem[i].getAttribute("cityid"));//Create a TextNode
					appendToSelect(city, cityElem[i].getAttribute("cityname"), textNode);//Call appendToSelect to append the text elements to the Territory dropdown
//                    alert(textNode);
//                        alert(parentElem.length);
				}
				childdropdownvalues  = dropdownvalues.split("+");

                for(i=0;i<childdropdownvalues.length;i++)
                    {
                        indchilddropdownvalues = childdropdownvalues[i].split(",");                        
						document.all(ddlchild).options[i] = new Option(indchilddropdownvalues[1],indchilddropdownvalues[0]);
                    }
				}
			}

			function appendToSelect(select, value, content)
			{
				var opt;
				opt = document.createElement("option");//Create an Element of type option
				opt.value = value;//Set the option's value
				
				if(dropdownvalues=='')
				{				 
				    dropdownvalues=opt.value;
				}
				else
				{
    				dropdownvalues  = dropdownvalues + '+' + opt.value;
				}
				
//				select.appendChild(opt);//Append the option to the referenced [Territory] select box

			}

			function clearSelect(select)
			{
				select.options.length = 1;//Set the select box's length to 1 so only "--Select--" is availale in the selection on calling this function.
										  //You may want to write your own clearSelect logic
			}

}