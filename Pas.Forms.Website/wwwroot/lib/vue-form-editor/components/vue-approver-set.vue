<template>
	<div style="padding: 10px; display: none; position: relative; height: 100%;" id="a1">
        <h3 class="page-title">设置审批人</h3>
        <hr />
        <div class="am-pop-cates content-center">
            <span v-for="(option, index) in approveCates" class="am-pop-cates-item">
                <input type="radio" v-model="cate" v-bind:value="option.value" :id="generateId('ac', index)" v-on:change="resetResult" />
                <label :for="generateId('ac', index)">{{option.text}}</label>
            </span>
        </div>
        <div v-show="cate==1">
            <div class="form-box">
                <div class="row">
                    <div class="label">主管级别</div>
                    <div class="control">
                        <select v-model="result[0].Level">
                            <option v-for="option in MasterLevels" v-bind:value="option.value">发起人的-{{ option.text }}</option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="label">审批方式</div>
                    <div class="control">
                        <select v-model="result[0].ApproveType">
                            <option v-for="option in pc1ApproveTypes" v-bind:value="option.value">{{ option.text }}</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <div v-show="cate==2">
            <div class="form-box">
                <div class="row">
                    <div class="label">类型</div>
                    <div class="control">
                        <div>
                            <select v-model="result[1].Type">
                                <option v-for="(option, index) in pc2Types" v-bind:value="option.value">{{option.text}}</option>
                            </select>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="label">&nbsp;</div>
                    <div class="control">
                        <div v-show="result[1].Type==1">
                            <span v-on:click="popJob(1)" class="btn btn-green btn-mini">选择职位</span>
                        </div>
                        <div v-show="result[1].Type==2">
                            <select v-model="result[1].Level">
                                <option v-for="opt in MasterLevels" v-bind:value="opt.value">{{ opt.text }}</option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div v-show="cate==3">
            <div class="form-box">
                <div class="row">
                    <div class="label">&nbsp;</div>
                    <div class="control">
                        <p class="font-gray">选择指定成员（单个节点审批人不能超过20）</p>
                        <ul>
                            <li v-for="(user, index) in result[2].Users" class="am-tag">
                                {{user.Name}}
                                <span v-on:click="deleteUser(3, index)" class="am-icon-del"><i class="fa fa-times"></i></span>
                            </li>
                        </ul>
                        <span v-on:click="popUser(3)" class="btn btn-green btn-mini">添加成员</span>
                    </div>
                </div>
            </div>
        </div>
        <div v-show="cate==4">
            <div class="form-box">
                <div class="label">&nbsp;</div>
                <div class="control">
                    <p>选择指定成员</p>
                    <div v-show="result[3].JobName.length > 0">
                        <span class="am-tag">{{result[3].JobName}}</span>
                    </div>
                    <span v-on:click="popJob(4)" class="btn btn-green btn-mini">指定岗位</span>
                </div>
            </div>
        </div>
        <div v-show="cate==5">
            <div class="form-box">
                <div class="label">&nbsp;</div>
                <div class="control">
                    <p>选择指定成员</p>
                    <span class="am-tag">发起人自己</span>
                </div>
            </div>
        </div>
        <div class="row" style="position:absolute; left: 0; right: 0; bottom: 0; border-top: 1px #ddd solid; padding: 10px">
            <div class="col-6">
                <div class="text-red">{{ approverError || "&nbsp;" }}</div>
            </div>
            <div class="col-6 content-right">
                <input type="button" class="btn btn-blue" value="确认" v-on:click="addApprover()" />
                <input type="button" class="btn btn-default" value="返回" />
            </div>
        </div>
    </div>
<template>

<script>
export default {
	name: 'vue-approver-set',
	props: {},
	data () {
		return {}
	},
	methods: {
	}
}
</script>