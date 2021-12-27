<?php /* Smarty version Smarty-3.0.7, created on 2011-05-19 00:35:48
         compiled from "../templates\content_booker_invite.tpl" */ ?>
<?php /*%%SmartyHeaderCode:308604dd43bb4944221-64160453%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '2ea8b560410aae3873291e9669b703448ba7a685' => 
    array (
      0 => '../templates\\content_booker_invite.tpl',
      1 => 1305497820,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '308604dd43bb4944221-64160453',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
)); /*/%%SmartyHeaderCode%%*/?>
<form name="booker_invite" action="<?php echo $_smarty_tpl->getVariable('formaction')->value;?>
" method="POST">
<input type="hidden" name="page" id="page" value="<?php echo $_smarty_tpl->getVariable('nextpage')->value;?>
" />
	<div class="post">
		<h1 class="title">
			<a>Vadītāju saraksts</a>
		</h1>
		<br/>
		<?php if (count($_smarty_tpl->getVariable('data_lecturers')->value)==0){?>
			<div class="text">
				<span>Neviens ieraksts nav atrasts. </span>
				<a href="javascript:location.reload(true)">Atjaunot datus.</a>
			</div>
		<?php }else{ ?>
			<div class="right" align="center">
				<table width="600" cellspacing="0" cellpadding="0">
					<tr class="head">
						<td>Vadītājs</td>
						<td align="center">Maksimālais studentu skaits</td>
						<td align="center">Izvēlēties</td>
					</tr>
					<?php  $_smarty_tpl->tpl_vars['lecturer'] = new Smarty_Variable;
 $_from = $_smarty_tpl->getVariable('data_lecturers')->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
if ($_smarty_tpl->_count($_from) > 0){
    foreach ($_from as $_smarty_tpl->tpl_vars['lecturer']->key => $_smarty_tpl->tpl_vars['lecturer']->value){
?>
						<tr>
							<td><?php echo $_smarty_tpl->tpl_vars['lecturer']->value['name'];?>
</td>
							<td align="center"><?php echo $_smarty_tpl->tpl_vars['lecturer']->value['qoute'];?>
</td>
							<td align="center">
								<input name='identities[]' type="checkbox"
									value="<?php echo $_smarty_tpl->tpl_vars['lecturer']->value['id'];?>
">
							</td>
						</tr>
					<?php }} ?>
				</table>
				<div class="action_block">
					<button name="invite" type="submit">Aicināt vadītājus</button>
				</div>
			</div>
		<?php }?>
	</div>
</form>
