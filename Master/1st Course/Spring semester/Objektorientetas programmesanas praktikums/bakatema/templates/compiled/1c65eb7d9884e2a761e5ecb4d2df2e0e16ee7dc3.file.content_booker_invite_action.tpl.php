<?php /* Smarty version Smarty-3.0.7, created on 2011-05-19 04:14:49
         compiled from "../templates\content_booker_invite_action.tpl" */ ?>
<?php /*%%SmartyHeaderCode:35674dd46f09ac5a40-20064508%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '1c65eb7d9884e2a761e5ecb4d2df2e0e16ee7dc3' => 
    array (
      0 => '../templates\\content_booker_invite_action.tpl',
      1 => 1305498922,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '35674dd46f09ac5a40-20064508',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
)); /*/%%SmartyHeaderCode%%*/?>
<form name="content_invite_action" action="<?php echo $_smarty_tpl->getVariable('formaction')->value;?>
" method="POST">
	<input type="hidden" name="page" id="page" value="<?php echo $_smarty_tpl->getVariable('nextpage')->value;?>
"/>
	<div class="post">
		<h1 class="title">
			<a>Aicināt vadītājus</a>
		</h1>
		<?php if (!$_smarty_tpl->getVariable('mode')->value){?>
			<div class="text">
				<b><?php echo $_smarty_tpl->getVariable('status')->value;?>
</b><br/>
				<button class="top_space" type="submit" name="back">Uz galveno</button>
			</div>
		<?php }elseif($_smarty_tpl->getVariable('mode')->value=='send_email'){?>
			<br/>
			<div class="text">
				<table cellspacing="0" border="0">
					<tr>
						<td class="spacing cell_size" valign="top"><b>E-pasts/-i:</b></td>
						<td class="bottom_space" align="left">
							<?php  $_smarty_tpl->tpl_vars['lecturer'] = new Smarty_Variable;
 $_from = $_smarty_tpl->getVariable('lecturers')->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
if ($_smarty_tpl->_count($_from) > 0){
    foreach ($_from as $_smarty_tpl->tpl_vars['lecturer']->key => $_smarty_tpl->tpl_vars['lecturer']->value){
?>
								<?php echo $_smarty_tpl->tpl_vars['lecturer']->value['email'];?>
;
								<input type="hidden" name='lecturersIds[]' value="<?php echo $_smarty_tpl->tpl_vars['lecturer']->value['id'];?>
" />
								&nbsp;
							<?php }} ?>
						</td>
					</tr>
					<tr>
						<td colspan="2"><b>Teksts:</b></td>
					</tr>
					<tr>
						<td colspan="2" class="bottom_space">
							<textarea rows="6" style="width:97%;"><?php echo $_smarty_tpl->getVariable('file_content')->value;?>
</textarea> 
							<input type="hidden" name="invite_text" value="<?php echo $_smarty_tpl->getVariable('file_content')->value;?>
" />
						</td>
					</tr>
					<tr>
						<td align="right" colspan="2">
							<div style="float: right">
								<button type="submit" name="send">Sūtīt</button>
								<button type="submit" name="back">Uz galveno</button>
							</div>
						</td>
					</tr>
				</table>
			</div>
		<?php }?>
	</div>
</form>