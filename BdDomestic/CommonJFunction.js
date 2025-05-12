// JScript File
function ClientValidate(source, arguments)
{
  //alert(arguments.Value);
  if ((arguments.Value) == 0)
     arguments.IsValid=false;
  else
     arguments.IsValid=true;
}

