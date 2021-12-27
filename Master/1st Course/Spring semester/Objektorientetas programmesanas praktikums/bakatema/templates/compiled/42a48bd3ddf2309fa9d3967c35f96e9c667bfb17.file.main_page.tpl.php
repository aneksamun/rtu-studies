<?php /* Smarty version Smarty-3.0.7, created on 2011-05-19 00:34:13
         compiled from "../templates\main_page.tpl" */ ?>
<?php /*%%SmartyHeaderCode:275584dd43b55aba470-19435331%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '42a48bd3ddf2309fa9d3967c35f96e9c667bfb17' => 
    array (
      0 => '../templates\\main_page.tpl',
      1 => 1305489816,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '275584dd43b55aba470-19435331',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
)); /*/%%SmartyHeaderCode%%*/?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/> 

  <title>Bakatema <?php echo $_smarty_tpl->getVariable('pagetitle')->value;?>
</title>
  <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>

<body>
  <div class="main">
	<?php $_template = new Smarty_Internal_Template('header.tpl', $_smarty_tpl->smarty, $_smarty_tpl, $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, null, null);
 echo $_template->getRenderedTemplate();?><?php unset($_template);?>

    <div class="content">
      <?php $_template = new Smarty_Internal_Template(($_smarty_tpl->getVariable('content')->value).".tpl", $_smarty_tpl->smarty, $_smarty_tpl, $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, null, null);
 echo $_template->getRenderedTemplate();?><?php unset($_template);?>  

      <div class="clear"></div>
    </div>

	<?php $_template = new Smarty_Internal_Template('footer.tpl', $_smarty_tpl->smarty, $_smarty_tpl, $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, null, null);
 echo $_template->getRenderedTemplate();?><?php unset($_template);?>
  </div>
</body>
</html>
