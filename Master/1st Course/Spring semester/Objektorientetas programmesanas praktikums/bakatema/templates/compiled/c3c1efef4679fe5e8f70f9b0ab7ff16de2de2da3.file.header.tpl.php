<?php /* Smarty version Smarty-3.0.7, created on 2011-05-19 00:34:13
         compiled from "../templates\header.tpl" */ ?>
<?php /*%%SmartyHeaderCode:63834dd43b55e9ae27-29887773%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'c3c1efef4679fe5e8f70f9b0ab7ff16de2de2da3' => 
    array (
      0 => '../templates\\header.tpl',
      1 => 1304545594,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '63834dd43b55e9ae27-29887773',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
)); /*/%%SmartyHeaderCode%%*/?>
    <div class="head">
    	<span class="logname">Labdien, <?php echo $_smarty_tpl->getVariable('username')->value;?>
 <?php if ($_smarty_tpl->getVariable('debug')->value){?> | lietotāju grupa: <?php echo $_smarty_tpl->getVariable('usergroup')->value;?>
 | lietotāja id: <?php echo $_smarty_tpl->getVariable('userid')->value;?>
 <?php }?></span>       
    </div>
    <div class="header">
      <div class="logo">
        <h1><a href="#">BAKATEMA</a></h1>
      </div>
      <p></p>
      <div class="clear"></div>
      
      <?php $_template = new Smarty_Internal_Template('menu.tpl', $_smarty_tpl->smarty, $_smarty_tpl, $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, null, null);
 echo $_template->getRenderedTemplate();?><?php unset($_template);?>
      
    </div>