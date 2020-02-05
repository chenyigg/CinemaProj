﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="Cinema.aspx.cs" Inherits="WebUI.Cinema234" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/reset.css">
    <link rel="stylesheet" href="Content/layout.css">
    <link rel="stylesheet" href="Content/ionicons.css">
    <link rel="stylesheet" href="Content/CinemaCss/Cinema.css">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/CinemaJs/cinema.js"></script>
    <script src="Scripts/vue.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <section id="content" class="row" onselectstart="return false">
	<div class="content--select">
		<div class="content--select__brand">
			<span class="content--select__text">
				品&nbsp;&nbsp;&nbsp;牌：&nbsp;&nbsp;
			</span>
			<ul class="content--select__container">
				<li class="flex-container_item content--select__brand--active">
					<span class="flex-container_item_text">
						万达影城
					</span>
				</li>
			</ul>
		</div>
		<div class="content--select__district">
			<span class="content--select__text">
				行政区： &nbsp;&nbsp;
			</span>
			<ul class="content--select__container">
				<li class="flex-container_item content--select__district--active" @click="AreaChange($event)">
					<span class="flex-container_item_text">
						全部
					</span>
				</li>
				<li class="flex-container_item" v-for="i in ListCinema" @click="AreaChange($event)">
					<span class="flex-container_item_text" v-cloak>
						{{i.CinemaArea}}
					</span>
				</li>
			</ul>
		</div>
		<div class="content--select__special">
			<span class="content--select__text">
				影厅类型：
			</span>
			<ul class="content--select__container">
				<li class="flex-container_item content--select__special--active" @click="TypeChange($event)">
					<span class="flex-container_item_text">
						全部
					</span>
				</li>
				<li class="flex-container_item" v-for="b in ListOffice" @click="TypeChange($event)">
					<span class="flex-container_item_text" v-cloak>
						{{b.OfficeName}}
					</span>
				</li>
			</ul>
		</div>
	</div>
	<div class="content--address">
		<span class="content--address--cinemaadd">
			影院列表
		</span>
		<div class="content--address--cinemalist" v-for="p in Cinema">
			<div class="content--address--cinemalist__item">
				<ul class="content--address--cinemalist__item--left">
					<li v-cloak>
						{{p.CinemaName}}
					</li>
					<li v-cloak>
						地址：{{p.CinemaAddress}}
					</li>
				</ul>
				<div class="content--address--cinemalist__item--right">
					<span>
						&yen;29.9
						<span style="font-size: 0.8em; color: gray;">
							起
						</span>
					</span>
					<span>
						<a :href="'ChooseOffice.aspx?CinemaID='+p.CinemaID">
							选座购票
						</a>
					</span>
				</div>
			</div>
		</div>
	</div>
</section>
</asp:Content>