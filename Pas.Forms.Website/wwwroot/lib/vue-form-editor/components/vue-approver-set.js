Vue.component('vue-approver-set', {
    render: function () { },
    props: {
        approver: null,
        cb: null
    },
    data: function () {
        return {
            origi: [
                {
                    Cate: 1,
                    Level: 1,
                    ApproveType: 1,
                    ToParentMasterIfNull: false
                },
                {
                    Cate: 2,
                    Level: 1,
                    JobId: '',
                    JobName: '',
                },
                {
                    Cate: 3,
                    Users: []
                },
                {
                    Cate: 4,
                    JobId: '',
                    JobName: '',
                    ApproveType: 1
                },
                {
                    Cate: 5,
                }
            ],
            result: null,
            options: {
                approveCates: [
                    { text: '主管-指定一级', value: '1' },
                    { text: '主管-连续多级', value: '2' },
                    { text: '指定成员', value: '3' },
                    { text: '岗位（一组固定成员）', value: '4' },
                    { text: '发起人自己', value: '5' }
                ],
                pc1ApproveTypes: [
                    { text: '依次审批', value: 1 },
                    { text: '会签', value: 2 },
                    { text: '或签', value: 3 }
                ],
                pc4ApproveTypes: [
                    { text: '会签', value: 2 },
                    { text: '或签', value: 3 }
                ],
                // 连续多级主管的类型
                pc2Types: [
                    { text: '直到属于指定角色的审批人，且该审批人同时是主管', value: '1' },
                    { text: '直到发起人向上的', value: '2' }
                ],
                // 级别
                MasterLevels: [
                    { text: '直接主管', value: 1 },
                    { text: '第二级主管', value: 2 },
                    { text: '第三级主管', value: 3 },
                    { text: '第四级主管', value: 4 },
                    { text: '第五级主管', value: 5 },
                    { text: '第六级主管', value: 6 },
                    { text: '第七级主管', value: 7 },
                    { text: '第八级主管', value: 8 },
                    { text: '第九级主管', value: 9 },
                    { text: '第十级主管', value: 10 }
                ],
            }

        };
    },
    methods: {

    }
});