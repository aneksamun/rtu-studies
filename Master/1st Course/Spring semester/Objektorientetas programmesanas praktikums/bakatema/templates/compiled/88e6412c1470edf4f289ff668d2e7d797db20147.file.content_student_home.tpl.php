<?php /* Smarty version Smarty-3.0.7, created on 2011-06-09 21:03:07
         compiled from "../templates\content_student_home.tpl" */ ?>
<?php /*%%SmartyHeaderCode:275694df10adbea50b1-67393854%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '88e6412c1470edf4f289ff668d2e7d797db20147' => 
    array (
      0 => '../templates\\content_student_home.tpl',
      1 => 1307642401,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '275694df10adbea50b1-67393854',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
)); /*/%%SmartyHeaderCode%%*/?>
<form name="student_home" action="<?php echo $_smarty_tpl->getVariable('formaction')->value;?>
" method="POST">
	<input type="hidden" name="page" id="page" value="<?php echo $_smarty_tpl->getVariable('nextpage')->value;?>
"/>
	<div class="post">
		<h1 class="title"><a>Izvēlētās tēmas stāvoklis:</a></h1>
		<br/>
		<?php if (!$_smarty_tpl->getVariable('data_thesis')->value){?>
			<div class="text">
				<span>Darba tēma nav izvēlēta.</span>
				<button name="select_thesis" type="submit">Izvēlēties tēmu</button>
			</div>
		<?php }else{ ?>
			<div class="right">
				<table width="100%" cellspacing="0" cellpadding="0">
					<tbody>
						<tr class="head">
							<td>Macībspēks</td>
							<td colspan="2">Latviskais nosaukums</td>
							<td colspan="2">Nosaukums angļu valodā</td>
						</tr>
						<tr>
							<td><b>Vadītājs:</b> <?php echo $_smarty_tpl->getVariable('data_thesis')->value['lecturer_name'];?>
</td>
							<td><?php echo $_smarty_tpl->getVariable('data_thesis')->value['native_title'];?>
</td>
							<td>
								<button name="edit_title" type="submit" value="<?php echo $_smarty_tpl->getVariable('data_thesis')->value['title_id_n'];?>
" class="edit">&nbsp</button>
							</td>
							<td><?php echo $_smarty_tpl->getVariable('data_thesis')->value['english_title'];?>
</td>
							<td>
								<button name="edit_title" type="submit" value="<?php echo $_smarty_tpl->getVariable('data_thesis')->value['title_id_e'];?>
" class="edit">&nbsp</button>
							</td>
						</tr>
						<tr>
							<td><b>Vadītāja e-pasts:</b> <?php echo $_smarty_tpl->getVariable('data_thesis')->value['lecturer_email'];?>
</td>
							<td colspan="2"><b>Pēdējo izmaiņu datums:</b> <?php echo $_smarty_tpl->getVariable('data_thesis')->value['revision_date_n'];?>
</td>
							<td colspan="2"><b>Pēdējo izmaiņu datums:</b> <?php echo $_smarty_tpl->getVariable('data_thesis')->value['revision_date_e'];?>
</td>
						</tr>
						<tr>
							<td>&nbsp</td>
							<td colspan="2"><b>Revīzijas numurs:</b> <?php echo $_smarty_tpl->getVariable('data_thesis')->value['revision_n'];?>
</td>
							<td colspan="2"><b>Revīzijas numurs:</b> <?php echo $_smarty_tpl->getVariable('data_thesis')->value['revision_e'];?>
</td>
						</tr>
						<tr>
							<td>&nbsp</td>
							<td colspan="2"><b>Vadītāja apstiprinājums:</b> <?php if ($_smarty_tpl->getVariable('data_thesis')->value['lect_approved_n']){?>Jā<?php }else{ ?>Nē<?php }?></td>
							<td colspan="2"><b>Vadītāja apstiprinājums:</b> <?php if ($_smarty_tpl->getVariable('data_thesis')->value['lect_approved_e']){?>Jā<?php }else{ ?>Nē<?php }?></td>
						</tr>
						<tr>
							<td><b>Bak. vadītājs:</b> <?php echo $_smarty_tpl->getVariable('data_thesis')->value['bach_name'];?>
</td>
							<td colspan="2"><b>Bak. vadītāja apstiprinājums:</b> <?php if ($_smarty_tpl->getVariable('data_thesis')->value['bach_approved_n']){?>Jā<?php }else{ ?>Nē<?php }?></td>
							<td colspan="2"><b>Bak. vadītāja apstiprinājums:</b> <?php if ($_smarty_tpl->getVariable('data_thesis')->value['bach_approved_e']){?>Jā<?php }else{ ?>Nē<?php }?></td>
						</tr>
						<tr>
							<td><b>Katedras vadītājs:</b> <?php echo $_smarty_tpl->getVariable('data_thesis')->value['cath_name'];?>
</td>
							<td colspan="2"><b>Katedras vadītāja apstiprinājums:</b> <?php if ($_smarty_tpl->getVariable('data_thesis')->value['cath_approved_n']){?>Jā<?php }else{ ?>Nē<?php }?></td>
							<td colspan="2"><b>Katedras vadītāja apstiprinājums:</b> <?php if ($_smarty_tpl->getVariable('data_thesis')->value['cath_approved_e']){?>Jā<?php }else{ ?>Nē<?php }?></td>
						</tr>
					</tbody>
				</table>
			</div>
		<?php }?>
		<br/>&nbsp;
		<br/>&nbsp;
		<button name="info" type="submit" value="<?php echo $_smarty_tpl->getVariable('data_thesis')->value['thesis_id'];?>
">Tēmas vēsture...</button>
		<br/>&nbsp;
	</div>
</form>