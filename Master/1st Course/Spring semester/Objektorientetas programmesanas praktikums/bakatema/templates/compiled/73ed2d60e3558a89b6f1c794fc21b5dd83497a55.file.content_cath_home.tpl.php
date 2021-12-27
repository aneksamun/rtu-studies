<?php /* Smarty version Smarty-3.0.7, created on 2011-05-19 01:37:28
         compiled from "../templates\content_cath_home.tpl" */ ?>
<?php /*%%SmartyHeaderCode:147784dd44a28284f08-41825401%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '73ed2d60e3558a89b6f1c794fc21b5dd83497a55' => 
    array (
      0 => '../templates\\content_cath_home.tpl',
      1 => 1305178406,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '147784dd44a28284f08-41825401',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
)); /*/%%SmartyHeaderCode%%*/?>
<form name="cath_home" action="<?php echo $_smarty_tpl->getVariable('formaction')->value;?>
" method="POST">
	<input type="hidden" name="page" id="page" value="<?php echo $_smarty_tpl->getVariable('nextpage')->value;?>
"/>
	<div class="post">
		<h1 class="title"><a>Nepieciešamo izskatīšanai tēmu saraksts:</a></h1>
		<br/>
		<?php if (count($_smarty_tpl->getVariable('data_titles')->value)==0){?>
			<div class="text">
				<span>Uz doto brīdi šādu tēmu nav.</span>
				<a href="javascript:location.reload(true)">Atjaunot datus</a>
			</div>
		<?php }else{ ?> 
			<div class="right">
				<table width="100%" cellspacing="0" cellpadding="0">
					<tr class="head">
						<td>Tēmas nosaukums</td>
						<td>Pēdējo izmaiņu datums</td>
						<td>Vadītājs</td>
						<td>Bak. Vadītājs</td>
						<td>Studenti</td>
						<td>Darbības</td>
					</tr>
					<?php  $_smarty_tpl->tpl_vars['i_title'] = new Smarty_Variable;
 $_from = $_smarty_tpl->getVariable('data_titles')->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
if ($_smarty_tpl->_count($_from) > 0){
    foreach ($_from as $_smarty_tpl->tpl_vars['i_title']->key => $_smarty_tpl->tpl_vars['i_title']->value){
?>
					<tr>
					    <td><?php echo $_smarty_tpl->tpl_vars['i_title']->value['native_title'];?>
</td>
					    <td><?php echo $_smarty_tpl->tpl_vars['i_title']->value['revision_date'];?>
</td>
					    <td><?php echo $_smarty_tpl->tpl_vars['i_title']->value['lecturer_name'];?>
</td>
					    <td><?php echo $_smarty_tpl->tpl_vars['i_title']->value['bach_lecturer_name'];?>
</td>
					    <td>
						    <?php  $_smarty_tpl->tpl_vars['i_student'] = new Smarty_Variable;
 $_from = $_smarty_tpl->tpl_vars['i_title']->value['applied_students']; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
if ($_smarty_tpl->_count($_from) > 0){
    foreach ($_from as $_smarty_tpl->tpl_vars['i_student']->key => $_smarty_tpl->tpl_vars['i_student']->value){
?>
						    	<?php echo $_smarty_tpl->getVariable('i_student')->value->firstName;?>
 <?php echo $_smarty_tpl->getVariable('i_student')->value->lastName;?>
<br/>
						    <?php }} ?>
					    </td>
					    <td>
					    	<button name="start_approve" type="submit" value="<?php echo $_smarty_tpl->tpl_vars['i_title']->value['title_id'];?>
">Apstiprināt</button>
					    	<button name="start_refuse" type="submit" value="<?php echo $_smarty_tpl->tpl_vars['i_title']->value['title_id'];?>
">Noraidīt</button>
					    	<button name="info" type="submit" value="<?php echo $_smarty_tpl->tpl_vars['i_title']->value['title_id'];?>
">Vairāk info...</button>
					    </td>
					</tr>
					<?php }} ?>
				</table>
			</div>
		<?php }?>
		<br/>&nbsp
	</div>
</form>