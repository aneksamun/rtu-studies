<?php /* Smarty version Smarty-3.0.7, created on 2011-05-19 00:34:13
         compiled from "../templates\menu.tpl" */ ?>
<?php /*%%SmartyHeaderCode:244734dd43b55f31be4-26281452%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'ba870f577ddf90c8d9583f6d8ebe39ff023a8278' => 
    array (
      0 => '../templates\\menu.tpl',
      1 => 1305151015,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '244734dd43b55f31be4-26281452',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
)); /*/%%SmartyHeaderCode%%*/?>
    <div class="menu">
      <ul>
      	<?php  $_smarty_tpl->tpl_vars['i_menu'] = new Smarty_Variable;
 $_from = $_smarty_tpl->getVariable('menu')->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
if ($_smarty_tpl->_count($_from) > 0){
    foreach ($_from as $_smarty_tpl->tpl_vars['i_menu']->key => $_smarty_tpl->tpl_vars['i_menu']->value){
?>
          <li <?php if ($_smarty_tpl->getVariable('i_menu')->value->selected){?>class="current"<?php }?>><a href="?page=<?php echo $_smarty_tpl->getVariable('i_menu')->value->page;?>
"><?php echo $_smarty_tpl->getVariable('i_menu')->value->title;?>
</a></li>
        <?php }} ?>
      </ul>
    </div>